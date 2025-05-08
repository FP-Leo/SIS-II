using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SIS.Application.Interfaces.Services;
using SIS.Domain.Entities;

namespace SIS.Persistence.Databases.Data.SeedData
{
    public static class IdentitySeeder
    {
        public static async Task SeedAdminAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var tokenService = services.GetRequiredService<ITokenService>();

            string userName = "10010010010";
            string email = "development@gmail.com";
            string password = "admin";
            string firstName = "Admin";
            string lastName = "Admin";
            string phoneNumber = "10010010010";
            var birthDate = new DateOnly(2000, 1, 1);
            var registerDate = DateOnly.FromDateTime(DateTime.UtcNow);
            string schoolMail = "admin@comu.edu.tr";

            var admin = await userManager.FindByNameAsync(userName);
            if (admin == null)
            {
                admin = new User
                {
                    UserName = userName,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    DateOfBirth = birthDate,
                    RegisterDate = registerDate,
                    SchoolMail = schoolMail
                };
                var result = await userManager.CreateAsync(admin, password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"- {error.Code}: {error.Description}");
                    }
                }

                result = await userManager.AddToRoleAsync(admin, "SuperUser");
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"- {error.Code}: {error.Description}");
                    }
                }
            }
        }
    }

}