using Microsoft.EntityFrameworkCore;

namespace InterProgApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProblem> UserProblem { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=InterProg;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(p => new { p.Email })
                        .IsUnique(true);

            modelBuilder.Entity<Course>()
                       .HasIndex(p => new { p.Name })
                       .IsUnique(true);
            modelBuilder.Entity<UserProblem>()
                        .HasKey(p => new {p.ProblemId, p.UserId});


            base.OnModelCreating(modelBuilder);
        }
    }
}