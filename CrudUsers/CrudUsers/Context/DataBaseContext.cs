using CrudUsers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudUsers.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext( DbContextOptions<DataBaseContext> options ) : base( options ) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<User>().HasKey( x => x.Id );
            modelBuilder.Entity<User>().HasOne( x => x.City ).WithMany().HasForeignKey( x => x.CityId ).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasMany(x => x.Roles).WithOne().HasForeignKey(x => x.Id);

            modelBuilder.Entity<Role>().HasKey(x => x.Id);
            
            modelBuilder.Entity<City>().HasKey(x => x.Id);
        }
    }
}
