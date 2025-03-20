using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Settimana6Giorno1.Models;

namespace Settimana6Giorno1.Data
{
    public class StudentDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }


        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.ApplicationUserRole)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.ApplicationUserRole)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Student>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.Students)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = new Guid("b1c0d0f2-3a7b-4f8d-9b6c-0e5e2d8c3f4a"),
                    Nome = "Rachele",
                    Cognome = "Barberis",
                    DataDiNascita = new DateTime(2001, 02, 03),
                    Email = "rachele.barberis@gmail.com"
                },
                 new Student
                 {
                     Id = new Guid("9d5e3b7c-2a4f-41d8-bf6c-7e8a1d9c0f2e"),
                     Nome = "Silvia",
                     Cognome = "Braghin",
                     DataDiNascita = new DateTime(2000, 06, 09),
                     Email = "silvia.braghin@gmail.com"
                 },
                  new Student
                  {
                      Id = new Guid("e7f4a9d1-5b3c-489a-8f21-1c6d9e7f2b3a"),
                      Nome = "Vittorio",
                      Cognome = "Turiaci",
                      DataDiNascita = new DateTime(2000, 07, 09),
                      Email = "vittorio.turiaci@gmail.com"
                  }

                );
        }


    }
}
