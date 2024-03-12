using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TaskBoard.Data.Configuration
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(new Board[]
            {
                ConfigurationHelper.OpenBoard,
                ConfigurationHelper.InProgressBoard,
                ConfigurationHelper.DoneBoard
            });
        }
    }
}
