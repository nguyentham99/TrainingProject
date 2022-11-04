using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrainingProject.Entities
{
    public class TrainingDbContext : IdentityDbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options)
           : base(options)
        {
        }
        public DbSet<AssignedTask> AssignedTask { get; set; }
        public DbSet<Status> Status { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignedTask>(e =>
            {
                e.HasKey(t => t.Id);
                e.Property(t => t.Subject).HasMaxLength(1000);
                e.Property(t => t.Description).HasMaxLength(1000);
            });
            modelBuilder.Entity<Status>(e =>
            {
                e.HasKey(t => t.Id);
                e.Property(sn => sn.StatusName).HasMaxLength(50);
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(e =>
            {
                e.HasKey(login => login.UserId);
            });
            modelBuilder.Entity<IdentityUserRole<string>>(e =>
            {
                e.HasKey(role => role.RoleId);
            });
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
        }
    }
}
