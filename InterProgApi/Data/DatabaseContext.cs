using System.Collections.Generic;
using InterProgApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace InterProgApi.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Problem> Problems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProblem> UserProblem { get; set; }

        public DatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=InterProg;Trusted_Connection=True;User Id=appuser;Password=password;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(p => new { p.Email })
                        .IsUnique(true);

            modelBuilder.Entity<Course>()
                       .HasIndex(p => new { p.Name })
                       .IsUnique(true);


            modelBuilder.Entity<Problem>()
                        .HasIndex(p => new { p.Name })
                        .IsUnique(true);

            modelBuilder.Entity<UserProblem>()
                        .HasKey(p => new { p.ProblemId, p.UserId });

            modelBuilder.Entity<Problem>()
              .Property(e => e.TestJson).HasConversion(
                  v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                  v => JsonConvert.DeserializeObject<TestInput>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            base.OnModelCreating(modelBuilder);
        }
    }
}