using Microsoft.EntityFrameworkCore;
using Event.Domain.Entities;

namespace Event.Infrastructure.Persistence
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<EventEntry> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Location).IsRequired();
                entity.Property(e => e.EventDate).IsRequired();
                entity.Property(e => e.CreatedBy).IsRequired();
            });
        }
    }
}
