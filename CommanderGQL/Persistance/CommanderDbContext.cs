using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Persistance
{
    public class CommanderDbContext:DbContext
    {
        public CommanderDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}
