using Microsoft.EntityFrameworkCore;

namespace UserProject.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(c => c.Age)
                .HasComputedColumnSql(
                    "DATEDIFF(YEAR, DateOfBirth, GETDATE()) - CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, DateOfBirth, GETDATE()), DateOfBirth) > GETDATE() THEN 1 ELSE 0 END"
                );


        }

        public DbSet<User> User { get; set; }
    }
}
