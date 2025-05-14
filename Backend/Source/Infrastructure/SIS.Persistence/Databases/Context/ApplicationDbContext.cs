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
        /// Gets or sets the DbSet for campus buildings.
        /// </summary>
        public DbSet<CampusBuilding> CampusBuildings { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for academic years.
        /// </summary>
        public DbSet<AcademicYear> AcademicYears { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for academic calendars.
        /// </summary>
        public DbSet<AcademicCalendar> AcademicCalendars { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for registration periods.
        /// </summary>
        public DbSet<RegistrationPeriod> RegistrationPeriods { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for exam periods.
        /// </summary>
        public DbSet<ExamPeriod> ExamPeriods { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for holidays.
        /// </summary>
        public DbSet<Holidays> Holidays { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for academic events.
        /// </summary>
        public DbSet<AcademicSemester> AcademicSemesters { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for academic programs.
        /// </summary>
        public DbSet<AcademicProgram> AcademicPrograms { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for program semesters.
        /// </summary>
        public DbSet<ProgramSemester> ProgramSemesters { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for student profiles.
        /// </summary>
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for lecturer profiles.
        /// </summary>
        public DbSet<LecturerProfile> LecturerProfiles { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for administrator profiles.
        /// </summary>
        public DbSet<AdministratorProfile> AdministratorProfiles { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for advisor profiles.
        /// </summary>
        public DbSet<AdvisorProfile> AdvisorProfiles { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for student program enrollments.
        /// </summary>
        public DbSet<StudentProgramEnrollment> StudentProgramEnrollments { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for lecturer assignments to departments.
        /// </summary>
        public DbSet<LecturerAssignment> LecturerAssignments { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for courses.
        /// </summary>
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for course offerings.
        /// </summary>
        public DbSet<CourseInstance> CourseInstances { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for course schedules.
        /// </summary>
        public DbSet<CourseSchedule> CourseSchedules { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for student enrollments.
        /// </summary>
        public DbSet<StudentCourseEnrollment> StudentCourseEnrollments { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for course assessments.
        /// </summary>
        public DbSet<Assessment> Assessments { get; set; }


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

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            //////////// Relationships
            /// University
            /*
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

            /// Academic Program
            
            modelBuilder.Entity<AcademicProgram>()
                .HasMany(a => a.PrerequisitePrograms)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AcademicProgramPrerequisite",
                    j => j
                        .HasOne<AcademicProgram>()
                        .WithMany()
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j
                        .HasOne<AcademicProgram>()
                        .WithMany()
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade));

            /// Courses

            modelBuilder.Entity<Course>()
                .HasMany(c => c.PrerequisiteCourses)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "CoursePrerequisite",
                    j => j
                        .HasOne<Course>()
                        .WithMany()
                        .HasForeignKey("PrerequisiteId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j
                        .HasOne<Course>()
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade));

            /// Lecturer Profile
            modelBuilder.Entity<LecturerProfile>()
                .HasOne(lp => lp.User)
                .WithOne()
                .HasForeignKey<LecturerProfile>(lp => lp.LecturerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            /// Student Profile
            modelBuilder.Entity<StudentProfile>()
                .HasOne(sp => sp.User)
                .WithOne()
                .HasForeignKey<StudentProfile>(sp => sp.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            /// Course Instance
            modelBuilder.Entity<CourseInstance>()
                .HasOne(ci => ci.LecturerAssignment)
                .WithMany(la => la.CourseInstances)
                .HasForeignKey(ci => ci.LecturerAssignmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CourseInstance>()
                .HasOne(ci => ci.ProgramSemester)
                .WithMany(ps => ps.CourseInstances)
                .HasForeignKey(ci => ci.ProgramSemesterId)
                .OnDelete(DeleteBehavior.Restrict);
            */


            // Add Roles
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            base.OnModelCreating(modelBuilder);
        }
    }
}