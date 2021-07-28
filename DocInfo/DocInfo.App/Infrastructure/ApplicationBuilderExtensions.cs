namespace DocInfo.App.Infrastructure
{
    using DocInfo.Data;
    using DocInfo.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app) 
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<DocDbContext>())
                {
                        dbContext.Database.Migrate();
                        //dbContext.Database.EnsureCreated();

                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    if (!roleManager.Roles.AnyAsync().GetAwaiter().GetResult())
                    {
                        dbContext.Add(new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" });
                        dbContext.Add(new IdentityRole() { Name = "Employee", NormalizedName = "EMPLOYEE" });
                        dbContext.Add(new IdentityRole() { Name = "User", NormalizedName = "USER" });
                    }

                    if (!userManager.Users.AnyAsync().GetAwaiter().GetResult())
                    {
                        var user = new ApplicationUser();
                        user.UserName = "Pesho";
                        //user.NormalizedUserName = "PESHO";
                        //user.Email = "pesho@pesho.bg";
                        var result = userManager.CreateAsync(user, "123456").GetAwaiter().GetResult();
                        userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
                    }

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
