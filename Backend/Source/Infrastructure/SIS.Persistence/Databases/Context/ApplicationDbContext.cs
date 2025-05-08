using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SIS.Common.Constants;

namespace SIS.Persistence.Databases.Context
{
    /// <summary>
    /// Represents the application's database context, extending the IdentityDbContext to include user and role management.
    /// </summary>
    public class ApplicationDbContext(DbContextOptions dbContextOptions) : IdentityDbContext<User>(dbContextOptions)
    {
        /// <summary>
        /// Gets or sets the DbSet for universities.
        /// </summary>
        public DbSet<University> Universities { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for faculties.
        /// </summary>
        public DbSet<Faculty> Faculties { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for departments.
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Configures the model relationships and seed data for the database.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure entity relationships and seed data.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // List of Roles.
            List<IdentityRole> roles = [
                new IdentityRole{Name = RoleConstants.Student, NormalizedName = RoleConstants.Student.ToUpper()},
                new IdentityRole{Name = RoleConstants.Lecturer, NormalizedName = RoleConstants.Lecturer.ToUpper()},
                new IdentityRole{Name = RoleConstants.Advisor, NormalizedName = RoleConstants.Advisor.ToUpper()},
                new IdentityRole{Name = RoleConstants.Administrator, NormalizedName = RoleConstants.Administrator.ToUpper()},
                new IdentityRole{Name = RoleConstants.Staff, NormalizedName = RoleConstants.Staff.ToUpper()},
                new IdentityRole{Name = RoleConstants.Rector, NormalizedName = RoleConstants.Rector.ToUpper()},
                new IdentityRole{Name = RoleConstants.Dean, NormalizedName = RoleConstants.Dean.ToUpper()},
                new IdentityRole{Name = RoleConstants.HoD, NormalizedName = RoleConstants.HoD.ToUpper()},
                new IdentityRole{Name = RoleConstants.SuperUser, NormalizedName = RoleConstants.SuperUser.ToUpper()}
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
                .HasForeignKey(f => f.UniversityId)
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