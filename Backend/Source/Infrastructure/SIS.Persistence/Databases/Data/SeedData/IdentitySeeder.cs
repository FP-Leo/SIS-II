using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SIS.Application.Interfaces.Services;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.Persistence.Databases.Data.SeedData
{
    public static class IdentitySeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var tokenService = services.GetRequiredService<ITokenService>();

            List<User> users = [
                new User{ UserName = "10010010010", Email = "l.shabani@gmail.com", FirstName = "Leonit", LastName = "Shabani",  PhoneNumber = "5388792975", DateOfBirth = new DateOnly(2001, 12, 04), RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow), SchoolMail = "l.shabani@comu.edu.tr"},
                new User{ UserName = "10010010020", Email = "c.erenoglu@gmail.com", FirstName = "Cüneyt", LastName = "ERENOĞLU",  PhoneNumber = "5001001000", DateOfBirth = new DateOnly(1980, 01, 01), RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow), SchoolMail = "rector@comu.edu.tr"},
                new User{ UserName = "10010010030", Email = "o.akcay@gmail.com", FirstName = "Özgün", LastName = "Akçay",  PhoneNumber = "5001001001", DateOfBirth = new DateOnly(1980, 01, 01), RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow), SchoolMail = "dekan-eng@comu.edu.tr"},
                new User{ UserName = "10010010040", Email = "i.kadayif@gmail.com", FirstName = "İsmail", LastName = "Kadayıf",  PhoneNumber = "5001001002", DateOfBirth = new DateOnly(1980, 01, 01), RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow), SchoolMail = "baskan-eng@comu.edu.tr"},
                new User{ UserName = "10010010050", Email = "erlindi.isaj@gmail.com", FirstName = "Erlindi", LastName = "Isaj",  PhoneNumber = "5001001003", DateOfBirth = new DateOnly(2002, 05, 03), RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow), SchoolMail = "200401114@comu.edu.tr"},
                new User{ UserName = "10010010060", Email = "i.kahraman@gmail.com", FirstName = "İsmail", LastName = "Kahraman",  PhoneNumber = "5001001004", DateOfBirth = new DateOnly(1980, 01, 01), RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow), SchoolMail = "i.kahraman@comu.edu.tr"},
                new User{ UserName = "10010010070", Email = "v.bayram@gmail.com", FirstName = "Vildan", LastName = "Bayram",  PhoneNumber = "5001001005", DateOfBirth = new DateOnly(1980, 01, 01), RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow), SchoolMail = "v.bayram@comu.edu.tr"},
                new User{ UserName = "10010010080", Email = "unknown.adm@gmail.com", FirstName = "Unknown", LastName = "Unknown",  PhoneNumber = "5001001006", DateOfBirth = new DateOnly(1980, 01, 01), RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow), SchoolMail = "admin-eng@comu.edu.tr"},
                new User{ UserName = "10010010090", Email = "f.kaya@gmail.com", FirstName = "Furkan", LastName = "Kaya",  PhoneNumber = "5001001007", DateOfBirth = new DateOnly(1980, 01, 01), RegisterDate = DateOnly.FromDateTime(DateTime.UtcNow), SchoolMail = "f.kaya@comu.edu.tr"},
            ];

            await SeedUser(userManager, tokenService, users[0], "admin", RoleConstants.SuperUser);
            await SeedUser(userManager, tokenService, users[1], "rector", RoleConstants.Rector);
            await SeedUser(userManager, tokenService, users[2], "dekan", RoleConstants.Dean);
            await SeedUser(userManager, tokenService, users[3], "baskan", RoleConstants.HoD);
            await SeedUser(userManager, tokenService, users[4], "student", RoleConstants.Student);
            await SeedUser(userManager, tokenService, users[5], "lecturer", RoleConstants.Lecturer);
            await SeedUser(userManager, tokenService, users[6], "advisor", RoleConstants.Advisor);
            await SeedUser(userManager, tokenService, users[7], "admin", RoleConstants.Administrator);
            await SeedUser(userManager, tokenService, users[8], "staff", RoleConstants.Staff);
        }

        public static async Task SeedUser(UserManager<User> userManager, ITokenService tokenService, User user, string password, string role)
        {
            if (user.UserName == null)
            {
                throw new ArgumentNullException(nameof(user.UserName));
            }

            var registeredUser = await userManager.FindByNameAsync(user.UserName);

            if (registeredUser == null)
            {
                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"- {error.Code}: {error.Description}");
                    }
                }

                result = await userManager.AddToRoleAsync(user, role);
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