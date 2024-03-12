using Homies.Data;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext data;
        public EventController(HomiesDbContext context)
        {
            data = context;
        }

        public async Task<IActionResult> All()
        {
            var events = await data.Events
                .AsNoTracking()
                .Select(e => new EventInfoViewModel(
                    e.Id,
                    e.Name,
                    e.Start,
                    e.Type.Name,
                    e.Organiser.UserName
                    ))
                .ToListAsync();

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var events = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (events == null)
            {
                return BadRequest();
            }

            string userid = GetUserId();

            if (!events.EventsParticipants.Any(p => p.HelperId == userid))
            {
                events.EventsParticipants.Add(new EventParticipant()
                {
                    EventId = events.Id,
                    HelperId = userid
                });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userid = GetUserId();

            var model =  await data.EventsParticipants
                .Where(ep => ep.HelperId == userid)
                .AsNoTracking()
                .Select(ep => new EventInfoViewModel(
                    ep.EventId,
                    ep.Event.Name,
                    ep.Event.Start,
                    ep.Event.Type.Name,
                    ep.Event.Organiser.UserName
                ))
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Leave(int id)
        {
            string userid = GetUserId();

            var events = await data.Events
               .Where(e => e.Id == id)
               .Include(e => e.EventsParticipants)
               .FirstOrDefaultAsync();

            if (events == null)
            {
                return BadRequest();
            }

            var ep = events.EventsParticipants.FirstOrDefault(ep => ep.HelperId == userid);

            if (ep == null) 
            { 
                return BadRequest();
            }

            events.EventsParticipants.Remove(ep);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormViewModel();

            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(model.Start, 
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(model.End,
               DataConstants.DateFormat,
               CultureInfo.InvariantCulture,
               DateTimeStyles.None,
               out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            var entity = new Event()
            {
                CreatedOn = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                OrganiserId = GetUserId(),
                TypeId = model.TypeId,
                Start = start,
                End = end
            };

            await data.Events.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var e = await data.Events.FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new EventFormViewModel()
            {
                Description = e.Description,
                Name = e.Name,
                End = e.End.ToString(DataConstants.DateFormat),
                Start = e.Start.ToString(DataConstants.DateFormat),
                TypeId = e.TypeId
            };

            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormViewModel model, int id)
        {
            var e = await data.Events.FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(model.End,
               DataConstants.DateFormat,
               CultureInfo.InvariantCulture,
               DateTimeStyles.None,
               out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            e.Start = start;
            e.End = end;
            e.Description = model.Description;
            e.Name = model.Name;
            e.TypeId = model.TypeId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await data.Events
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new EventDetailsViewModel()
                {
                    Name = e.Name,
                    Start = e.Start.ToString(DataConstants.DateFormat),
                    End = e.End.ToString(DataConstants.DateFormat),
                    CreatedOn = e.CreatedOn.ToString(DataConstants.DateFormat),
                    Description = e.Description,
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name,
                    Id = e.Id
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<TypeViewModel>> GetTypes()
        {
            return await data.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
}