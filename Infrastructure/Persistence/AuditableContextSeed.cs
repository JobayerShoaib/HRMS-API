using Application.IdentityEntities;
using Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AuditableContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var administratorRole = new ApplicationRole("Super Admin", "Super Admin in this application");
            administratorRole.IsSuperAdmin = true;
            administratorRole.CreatedBy = "Self";
            administratorRole.CreatedOn = DateTime.Now;

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "admin", Email = "jobayershoaib@gmail.com", CreatedOn = DateTime.Now, CreatedBy = "1", IsActive = true, IsDeleted = false };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "admin123");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        private static async Task SaveUserHelper(HRMDbContext context)
        {
            var user = await context.Users.FirstAsync();
            if (user != null)
            {
                if (!context.AuditSecrets.Any())
                {
                    context.AuditSecrets.Add(new AuditSecrets() { UserID = user.Id, UserName = user.UserName, Secret = "admin123" });
                    await context.SaveChangesAsync();
                }
            }
        }

        public static async Task SeedSampleDataAsync(HRMDbContext context)
        {
            // Seed, if necessary
            //if (!context.TodoLists.Any())
            //{
            //    context.TodoLists.Add(new TodoList
            //    {
            //        Title = "Shopping",
            //        Colour = Colour.Blue,
            //        Items =
            //        {
            //            new TodoItem { Title = "Apples", Done = true },
            //            new TodoItem { Title = "Milk", Done = true },
            //            new TodoItem { Title = "Bread", Done = true },
            //            new TodoItem { Title = "Toilet paper" },
            //            new TodoItem { Title = "Pasta" },
            //            new TodoItem { Title = "Tissues" },
            //            new TodoItem { Title = "Tuna" },
            //            new TodoItem { Title = "Water" }
            //        }
            //    });

            //    await context.SaveChangesAsync();
            //}
        }
    }
}
