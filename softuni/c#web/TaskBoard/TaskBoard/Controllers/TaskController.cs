using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoard.Data;
using TaskBoard.Models;

namespace TaskBoard.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public TaskController(TaskBoardAppDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormViewModel taskModel = new TaskFormViewModel()
            {
                Boards = await GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormViewModel model)
        {
            if (!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist!");
            }
            if (!ModelState.IsValid)
            {
                model.Boards = await GetBoards();

                return View(model);
            }

            var entity = new Data.Task()
            {
                BoardId = model.BoardId,
                CreatedOn = DateTime.Now,
                Description = model.Description,
                OwnerId = GetUserId(),
                Title = model.Title
            };

            await data.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction("Index", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await data.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Board = t.Board.Name,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.Value.ToString("dd/MM/yyyy HH:mm"),
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            if (task.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new TaskFormViewModel()
            {
                Title = task.Title,
                BoardId = task.Id,
                Description = task.Description,
                Boards = await GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskFormViewModel model, int id)
        {
            var task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            if (task.OwnerId != GetUserId())
            {
                return Unauthorized();
            }
            if (!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist!");
            }
            if (!ModelState.IsValid)
            {
                model.Boards = await GetBoards();
                return View(model);
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await data.SaveChangesAsync();
            return RedirectToAction("Index", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            if (task.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel model)
        {
            var task = await data.Tasks.FindAsync(model.Id);

            if (task == null)
            {
                return BadRequest();
            }

            if (task.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            data.Tasks.Remove(task);
            await data.SaveChangesAsync();

            return RedirectToAction("Index", "Board");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<IEnumerable<TaskBoardModel>> GetBoards()
        {
           return await data.Boards
                .Select(b => new TaskBoardModel
            {
                Id = b.Id,
                Name = b.Name,
            })
            .ToListAsync();
        }
    }
}
