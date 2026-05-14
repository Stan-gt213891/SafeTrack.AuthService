using Microsoft.EntityFrameworkCore;
using SafeTrack.AuthService.Models;

namespace SafeTrack.AuthService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
    }
}