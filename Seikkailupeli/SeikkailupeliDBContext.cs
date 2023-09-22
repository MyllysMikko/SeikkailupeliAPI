using Microsoft.EntityFrameworkCore;

namespace Seikkailupeli
{
    public class SeikkailupeliDBContext : DbContext
    {
        public SeikkailupeliDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Quest> Quests { get; set; }

    }
}
