using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ForumApp.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ForumDbContext context;
        private readonly ILogger logger;

        public PostService(ForumDbContext _context, ILogger<PostService> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public async Task AddAsync(PostModel model)
        {
            var entity = new Post()
            {
                Title = model.Title,
                Content = model.Content,
            };

            try
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "PostService.AddAsync");
                throw new ApplicationException("Operation failed. Please try again!");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.FindAsync<Post>(id);

            if (entity == null)
            {
                throw new ApplicationException("Invalid post!");
            }

            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(PostModel model)
        {
            var entity = await context.FindAsync<Post>(model.Id);

            if (entity == null)
            {
                throw new ApplicationException("Invalid post!");
            }

            entity.Title = model.Title;
            entity.Content = model.Content;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostModel>> GetAllPostsAsync()
        {
            return await context.Posts
                .Select(p => new PostModel()
                {
                    Content = p.Content,
                    Id = p.Id,
                    Title = p.Title
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PostModel?> GetByIdAsync(int id)
        {
            return await context.Posts.Where(p => p.Id == id)
                .Select(p => new PostModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                }).AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}