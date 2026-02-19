using JWTRbacAuthProject.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JWTRbacAuthProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<User> Users => Set<User>();
    }
}
