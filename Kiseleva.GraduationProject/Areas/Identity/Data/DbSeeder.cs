using Kiseleva.GraduationProject.Areas.Identity.Data;
using KvalExample.Constants;
using Microsoft.AspNetCore.Identity;

namespace KvalExample.Areas.Identity.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<ApplicationUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();
            //adding some roles to db
            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.Manager.ToString()));

            // create admin user

            var admin = new ApplicationUser
            {
                UserName = "Admin",
                Email = "admin@mail.ru",
                LastName = "Антонова",
                FirstName = "Анастасия",
                MiddleName = "Павловна",
                PhoneNumber = "89285551463",
                EmailConfirmed = true
            };

            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            if (userInDb is null)
            {
                await userMgr.CreateAsync(admin, "Qwq12345!");
                await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }
    }
}
