namespace DocInfo.App.Infrastructure
{
    using DocInfo.Common;
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
                        dbContext.Add(new IdentityRole 
                        { 
                            Name = GlobalConstants.AdministratorRoleName, 
                            NormalizedName = GlobalConstants.AdministratorRoleName.ToUpper() 
                        });
                        dbContext.Add(new IdentityRole 
                        { 
                            Name = GlobalConstants.EmployeeRoleName, 
                            NormalizedName = GlobalConstants.EmployeeRoleName.ToUpper() 
                        });
                        dbContext.Add(new IdentityRole
                        { 
                            Name = GlobalConstants.UserRoleName,
                            NormalizedName = GlobalConstants.UserRoleName.ToUpper() 
                        });
                    }

                    if (!userManager.Users.AnyAsync().GetAwaiter().GetResult())
                    {
                        var user = new ApplicationUser();
                        user.UserName = "Pesho";
                        //user.NormalizedUserName = "PESHO";
                        //user.Email = "pesho@pesho.bg";
                        var result = userManager.CreateAsync(user, GlobalConstants.Password).GetAwaiter().GetResult();
                        userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName).GetAwaiter().GetResult();

                        //var userOne = new ApplicationUser();
                        //userOne.UserName = "Gosho";
                        //var result1 = userManager.CreateAsync(userOne, GlobalConstants.Password).GetAwaiter().GetResult();
                        //userManager.AddToRoleAsync(userOne, GlobalConstants.UserRoleName).GetAwaiter().GetResult();

                        //var userTwo = new ApplicationUser();
                        //userTwo.UserName = "Kiro";
                        //var result2 = userManager.CreateAsync(userTwo, GlobalConstants.Password).GetAwaiter().GetResult();
                        //userManager.AddToRoleAsync(userTwo, GlobalConstants.UserRoleName).GetAwaiter().GetResult();

                        //var userThree = new ApplicationUser();
                        //userThree.UserName = "Mima";
                        //var result3 = userManager.CreateAsync(userThree, GlobalConstants.Password).GetAwaiter().GetResult();
                        //userManager.AddToRoleAsync(userThree, GlobalConstants.UserRoleName).GetAwaiter().GetResult();
                    }

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
