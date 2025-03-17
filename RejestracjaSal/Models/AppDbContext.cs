using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace RejestracjaSal.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet <Users> Users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Users> users = new List<Users>
            {
                new Users()
                {
                    User_id = 1,
                    Name = "Admin",
                    Email = "Admin@gmail.com",
                    Phone = 698785383,
                    Role_id = 2,
                    Login = "Admin",
                    Password = "Admin"

                }
            };

            modelBuilder.Entity<Users>().HasData(users);
        }
    }
}
