using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIS.Domain.Entities;
using SIS.Domain.Shared;
using SIS.Persistence.Databases.Context;

namespace SIS.Persistence.Databases.Data.SeedData
{
    public static class AppSeeder
    {
        public static async Task SeedCoreDataAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<User>>();

            // Seed university if not exists
            var university = await context.Universities
                .FirstOrDefaultAsync(u => u.Abbreviation == "COMU");

            if (university == null)
            {
                User rector = await userManager.FindByNameAsync("10010010020") ?? throw new InvalidOperationException("Rector not found. Please create a user with username '10010010020'.");
                
                university = new University
                {
                    Name = "Çanakkale Onsekiz Mart University",
                    Abbreviation = "COMU",
                    Address = "Terzioğlu Campus, 17100 Çanakkale, Turkey",
                    RectorId = rector.Id
                };

                await context.Universities.AddAsync(university);
                await context.SaveChangesAsync();
            }

            // Seed faculty if not exists
            if (!await context.Faculties.AnyAsync(f => f.Code == "ENG"))
            {
                User dean = await userManager.FindByNameAsync("10010010030") ?? throw new InvalidOperationException("Dean not found. Please create a user with username '10010010030'.");
                
                var faculty = new Faculty
                {
                    Name = "Faculty of Engineering",
                    Code = "ENG",
                    Address = "Terzioğlu Campus, 17100 Çanakkale, Turkey",
                    PhoneNumber = "+90 286 218 00 00",
                    IsActive = true,
                    UniversityId = university.Id,
                    DeanId = dean.Id
                };

                await context.Faculties.AddAsync(faculty);
                await context.SaveChangesAsync();
            }

            // Seed departments if not exists
            if (!await context.Departments.AnyAsync(d => d.Code == "CPE"))
            {
                Faculty faculty = await context.Faculties.FirstOrDefaultAsync(f => f.Code == "ENG") ?? throw new InvalidOperationException("Faculty not found. Please create a faculty with code 'ENG'.");
                User hod = await userManager.FindByNameAsync("10010010040") ?? throw new InvalidOperationException("HoD not found. Please create a user with username '10010010040'.");

                var department = new Department
                {
                    Name = "Computer Engineering",
                    Code = "CPE",
                    Address = "Terzioğlu Campus, 17100 Çanakkale, Turkey",
                    PhoneNumber = "+90 286 218 00 00",
                    IsActive = true,
                    FacultyId = faculty.Id,
                    HeadOfDepartmentId = hod.Id,
                };

                await context.Departments.AddAsync(department);
                await context.SaveChangesAsync();
            }

            if (!await context.Courses.AnyAsync())
            {
                Department dep = await context.Departments.FirstOrDefaultAsync(d => d.Code == "CPE") ?? throw new InvalidOperationException("Department not found. Please create a department with code 'CSE'.");
            
                var course_One = new Course
                {
                    Name = "Introduction to Computer Engineering",
                    Code = "CPE-1001",
                    Type = CourseType.Core,
                    Description = "An introduction to the field of computer engineering.",
                    Credits = 3,
                    Level = Domain.Shared.Level.Undergraduate,
                    PrerequisiteCourseIds = [],
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    DepartmentId = dep.Id
                };

                await context.Courses.AddAsync(course_One);

                var course_Two = new Course
                {
                    Name = "Data Structures",
                    Code = "CPE-1002",
                    Type = CourseType.Core,
                    Description = "An introduction to data structures.",
                    Credits = 3,
                    Level = Domain.Shared.Level.Undergraduate,
                    PrerequisiteCourseIds = [course_One.Id],
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    DepartmentId = dep.Id
                };

                await context.Courses.AddAsync(course_Two);

                var course_Three = new Course
                {
                    Name = "Mathematics I",
                    Code = "CPE-1003",
                    Type = CourseType.Core,
                    Description = "An introduction to mathematics.",
                    Credits = 3,
                    Level = Domain.Shared.Level.Undergraduate,
                    PrerequisiteCourseIds = [],
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    DepartmentId = dep.Id
                };

                await context.Courses.AddAsync(course_Three);

                var course_Four = new Course
                {
                    Name = "Mathematics II",
                    Code = "CPE-1004",
                    Type = CourseType.Core,
                    Description = "An introduction to advanced mathematics.",
                    Credits = 3,
                    Level = Domain.Shared.Level.Undergraduate,
                    PrerequisiteCourseIds = [course_Three.Id],
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    DepartmentId = dep.Id
                };

                await context.Courses.AddAsync(course_Four);

                var course_Five = new Course
                {
                    Name = "Physics I",
                    Code = "CPE-1005",
                    Type = CourseType.Core,
                    Description = "An introduction to physics.",
                    Credits = 3,
                    Level = Domain.Shared.Level.Undergraduate,
                    PrerequisiteCourseIds = [],
                    CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    DepartmentId = dep.Id
                };
                
                await context.Courses.AddAsync(course_Five);

                await context.SaveChangesAsync();
            }        
        }
    }
}
