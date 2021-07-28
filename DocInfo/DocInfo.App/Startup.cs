namespace DocInfo.App
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using DocInfo.Data;
    using DocInfo.Data.Repositories;
    using DocInfo.App.Infrastructure;
    using DocInfo.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<DocDbContext>(options => options
                .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")))
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings( this.Configuration))
                .AddSwagger()
                .AddControllers();

            // Data repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Application services
            services.AddTransient<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyMigrations();

            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocInfo.App API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors(options => 
            options
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}