using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext data;

        public SeminarController(SeminarHubDbContext context)
        {
            data = context;
        }

        public async Task<IActionResult> All()
        {
            var seminars = await data.Seminars
                .AsNoTracking()
                .Select(s => new AllSeminarsViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Category.Name,
                    s.DateAndTime,
                    s.Organizer.UserName
                    ))
                .ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddSeminarsViewModel();
            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSeminarsViewModel model)
        {
            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
              model.DateAndTime,
              DataConstants.DateFormat,
              CultureInfo.InvariantCulture,
              DateTimeStyles.None,
              out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var entity = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                DateAndTime = dateAndTime,
                Duration = model.Duration,
                CategoryId = model.CategoryId,
                OrganizerId = GetUserId()
            };

            await data.Seminars.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var joinedSeminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (joinedSeminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!joinedSeminar.SeminarsParticipants.Any(p => p.ParticipantId == userId))
            {
                joinedSeminar.SeminarsParticipants.Add(new SeminarParticipant()
                {
                    SeminarId = joinedSeminar.Id,
                    ParticipantId = userId
                });

                await data.SaveChangesAsync();
                return RedirectToAction(nameof(Joined));
            }
            else
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var model = await data.SeminarsParticipants
                .Where(sp => sp.ParticipantId == userId)
                .AsNoTracking()
                .Select(sp => new AllSeminarsViewModel(
                    sp.SeminarId,
                    sp.Seminar.Topic,
                    sp.Seminar.Lecturer,
                    sp.Seminar.Category.Name,
                    sp.Seminar.DateAndTime,
                    sp.Seminar.Organizer.UserName
                    ))
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var seminarParticipant = seminar.SeminarsParticipants
                .FirstOrDefault(sp => sp.ParticipantId == userId);

            if (seminarParticipant == null)
            {
                return BadRequest();
            }

            seminar.SeminarsParticipants.Remove(seminarParticipant);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminarToEdit = await data.Seminars.FindAsync(id);

            if (seminarToEdit == null)
            {
                return BadRequest();
            }

            if (seminarToEdit.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new AddSeminarsViewModel()
            {
                Topic = seminarToEdit.Topic,
                Lecturer = seminarToEdit.Lecturer,
                Details = seminarToEdit.Details,
                DateAndTime = seminarToEdit.DateAndTime.ToString(DataConstants.DateFormat),
                Duration = seminarToEdit.Duration,
                CategoryId = seminarToEdit.CategoryId
            };

            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddSeminarsViewModel model, int id)
        {
            var seminar = await data.Seminars.FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            seminar.Topic = model.Topic;
            seminar.Lecturer = model.Lecturer;
            seminar.Details = model.Details;
            seminar.DateAndTime = dateAndTime;
            seminar.Duration = model.Duration;
            seminar.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await data.Seminars
                .Where(s => s.Id == id)
                .AsNoTracking()
                .Select(s => new SeminarsDetailsViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime.ToString(DataConstants.DateFormat),
                    Duration = s.Duration,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    Details = s.Details,
                    Organizer = s.Organizer.UserName
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var seminar = await data.Seminars.FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new DeleteSeminarViewModel()
            {
                Id = seminar.Id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteSeminarViewModel model)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == model.Id)
                .Include(sp => sp.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != seminar.OrganizerId)
            {
                return Unauthorized();
            }

            var seminarParticipant = seminar.SeminarsParticipants.FirstOrDefault(sp => sp.SeminarId == seminar.Id);

            if (seminarParticipant != null)
            {
                data.SeminarsParticipants.Remove(seminarParticipant);
            }

            data.Seminars.Remove(seminar);
            await data.SaveChangesAsync();

            return RedirectToAction("All", "Seminar");
        }

        private async Task<IList<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}