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
        public DbSet<FamilyMember> FamilyMembers => Set<FamilyMember>();
        public DbSet<Geofence> Geofences => Set<Geofence>();
        public DbSet<Alert> Alerts => Set<Alert>();
        public DbSet<Location> Locations => Set<Location>();
    }

}