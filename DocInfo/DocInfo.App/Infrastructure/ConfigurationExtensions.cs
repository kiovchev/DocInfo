using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocInfo.App.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static ApplicationSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<ApplicationSettings>();
        }
    }
}
