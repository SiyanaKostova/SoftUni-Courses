using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoard.Data;
using TaskBoard.Models;

namespace TaskBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public HomeController(TaskBoardAppDbContext context)
        {
            data = context;
        }

        public async Task<IActionResult> Index()
        {
            var taskBoards = data.Boards.Select(b => b.Name).Distinct();

            var tasksCount = new List<HomeBoardModel>();

            foreach (var boardName in taskBoards)
            {
                var tasksInBoard = data.Tasks.Where(t => t.Board.Name == boardName).Count();
                tasksCount.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TasksCount = tasksInBoard
                });
            }

            var userTasksCount = -1;

            if (User.Identity.IsAuthenticated)
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userTasksCount = data.Tasks.Where(t => t.OwnerId == currentUserId).Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = data.Tasks.Count(),
                BoardsWithTasksCount = tasksCount,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }
    }
}
