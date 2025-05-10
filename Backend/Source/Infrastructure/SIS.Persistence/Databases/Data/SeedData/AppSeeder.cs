using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIS.Domain.Entities;
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
                var rector = await userManager.FindByNameAsync("10010010020") ?? throw new InvalidOperationException("Rector not found. Please create a user with username '10010010020'.");
                
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
                var dean = await userManager.FindByNameAsync("10010010030") ?? throw new InvalidOperationException("Dean not found. Please create a user with username '10010010020'.");
                
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
        }
    }
}
