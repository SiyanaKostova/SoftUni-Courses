using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.Data.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        private Post[] initialPosts = new Post[]
        {
            new Post() { Id=1, Title="My first post", Content="First post content" },
            new Post() { Id=2, Title="My second post", Content="Second post content" },
            new Post() { Id=3, Title="My third post", Content="Third post content" }
        };
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(initialPosts);
        }
    }
}
