using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
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
                .Select(e => new AllEventsViewModel(
                    e.Id,
                    e.Name,
                    e.Organiser.UserName,
                    e.Start,
                    e.Type.Name
                    ))
                .ToListAsync();

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var joinedEvent = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (joinedEvent == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!joinedEvent.EventsParticipants.Any(p => p.HelperId == userId))
            {
                joinedEvent.EventsParticipants.Add(new EventParticipant()
                {
                    EventId = joinedEvent.Id,
                    HelperId = userId
                });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var model = await data.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .AsNoTracking()
                .Select(ep => new AllEventsViewModel(
                    ep.EventId,
                    ep.Event.Name,
                    ep.Event.Organiser.UserName,
                    ep.Event.Start,
                    ep.Event.Type.Name
                    ))
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var joinedEvent = await data.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (joinedEvent == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var eventParticipant = joinedEvent.EventsParticipants
                .FirstOrDefault(ep => ep.HelperId == userId);

            if (eventParticipant == null)
            {
                return BadRequest();
            }

            joinedEvent.EventsParticipants.Remove(eventParticipant);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await data.Events
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DataConstants.DateFormat),
                    End = e.End.ToString(DataConstants.DateFormat),
                    Organiser = e.Organiser.UserName,
                    CreatedOn = e.CreatedOn.ToString(DataConstants.DateFormat),
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddEventsViewModel();
            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventsViewModel model)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
              model.Start,
              DataConstants.DateFormat,
              CultureInfo.InvariantCulture,
              DateTimeStyles.None,
              out start))
            {
                ModelState
                    .AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState
                    .AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            var entity = new Event()
            {
                CreatedOn = DateTime.Now,
                Start = start,
                End = end,
                Description = model.Description,
                Name = model.Name,
                OrganiserId = GetUserId(),
                TypeId = model.TypeId,
            };

            await data.Events.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventToEdit = await data.Events.FindAsync(id);

            if (eventToEdit == null)
            {
                return BadRequest();
            }

            if (eventToEdit.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new AddEventsViewModel()
            {
                Description = eventToEdit.Description,
                Name = eventToEdit.Name,
                Start = eventToEdit.Start.ToString(DataConstants.DateFormat),
                End = eventToEdit.End.ToString(DataConstants.DateFormat),
                TypeId = eventToEdit.TypeId
            };

            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEventsViewModel model, int id)
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

            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState
                    .AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState
                    .AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
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

            private async Task<IList<TypeViewModel>> GetTypes()
        {
            return await data.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
