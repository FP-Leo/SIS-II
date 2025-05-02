using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SIS.Persistence.Databases.Context
{
    public class ApplicationDbContext(DbContextOptions dbContextOptions) : IdentityDbContext<User>(dbContextOptions)
    {
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // List of Roles.
            List<IdentityRole> roles = [
                new IdentityRole{
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
                new IdentityRole{
                    Name = "Lecturer",
                    NormalizedName = "LECTURER"
                },
                new IdentityRole{
                    Name = "Advisor",
                    NormalizedName = "ADVISOR"
                },
                new IdentityRole{
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "Staff",
                    NormalizedName = "STAFF"
                }
            ];
            //////////// Relationships
            /// University

            // One to One relationship between University and User (Rector)
            modelBuilder.Entity<University>()
                .HasOne(u => u.Rector)
                .WithMany() // WithMany() is used when the principal entity (in this case, User) doesn't have a navigation property pointing back to the dependent entity (Faculty or University), even if the relationship is conceptually one-to-one.
                .HasForeignKey(uid => uid.RectorId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade from University to User

            /// Faculty

            // One to One relationship between Faculty and User (Dean)
            modelBuilder.Entity<Faculty>()
                .HasOne(u => u.Dean)
                .WithMany() 
                .HasForeignKey(uid => uid.DeanId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade from Faculty to User

            // One to Many relationship between University and Faculty
            modelBuilder.Entity<Faculty>()
                .HasOne(f => f.University)
                .WithMany(u => u.Faculties)
                .HasForeignKey(f => f.UniId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade from University to Faculty, to avoid deleting all faculties when a university is deleted. Loss of data is not acceptable.

            /// Department

            // One to One relationship between Department and User (Head of Department)
            modelBuilder.Entity<Department>()
                .HasOne(u => u.HeadOfDepartment)
                .WithMany()
                .HasForeignKey(uid => uid.HeadOfDepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade from Department to User

            // One to Many relationship between Faculty and Department
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Faculty)
                .WithMany(f => f.Departments)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade from Faculty to Department

            // Add Roles
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            base.OnModelCreating(modelBuilder);
        }
    }

}