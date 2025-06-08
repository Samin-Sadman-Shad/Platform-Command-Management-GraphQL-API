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
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Platform>()
            //    .HasMany(p => p.Commands)
            //    .WithOne(c => c.Platform)
            //    .HasForeignKey(p => p.PlatformId);

            //modelBuilder.Entity<Platform>()
            //    .Property(e => e.Id)
            //    .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Platform>(platformBuilder =>
            {
                platformBuilder.HasKey(platform => platform.Id);

                platformBuilder.HasMany(p => p.Commands)
                .WithOne(c => c.Platform)
                .HasForeignKey(P => P.PlatformId);

                platformBuilder.Property(platform => platform.Id)
                    .HasDefaultValueSql("NEWSEQUENTIALID()");
            });

            modelBuilder.Entity<Command>(commandBuilder =>
            {
                commandBuilder.HasKey(command => command.Id);

                commandBuilder.HasOne(command => command.Platform)
                            .WithMany(platform => platform.Commands)
                            .HasForeignKey(command => command.PlatformId);

                commandBuilder.Property(command => command.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            });

            //modelBuilder.Entity<Command>()
            //    .HasOne(c => c.Platform)
            //    .WithMany(p => p.Commands)
            //    .HasForeignKey(p => p.PlatformId);

            //modelBuilder.Entity<Command>()
            //    .Property(e => e.Id)
            //    .HasDefaultValueSql("NEWSEQUENTIALID()");
        }
    }
}
