using Microsoft.EntityFrameworkCore;
using Notice.Domain.Entities;

namespace Notice.Infrastructure.Persistence
{
    public class NoticeDbContext : DbContext
    {
        public NoticeDbContext(DbContextOptions<NoticeDbContext> options) : base(options)
        {
        }

        public DbSet<NoticeEntry> Notices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoticeEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.PostedBy).IsRequired();
            });
        }
    }
}
