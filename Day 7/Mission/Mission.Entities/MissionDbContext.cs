using Mission.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Mission.Entities
{
    public class MissionDbContext : DbContext
    {
        public MissionDbContext(DbContextOptions<MissionDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<MissionSkill> MissionSkills { get; set; }

        public DbSet<MissionTheme> MissionThemes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Models.Mission> Missions { get; set; }

        public DbSet<MissionApplication> MissionApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Meet",
                EmailAddress = "admin@meet.com",
                Password = "admin",
                PhoneNumber = "01234567890",
                UserType = "admin",
            });


            base.OnModelCreating(modelBuilder);
        }
    }

}
