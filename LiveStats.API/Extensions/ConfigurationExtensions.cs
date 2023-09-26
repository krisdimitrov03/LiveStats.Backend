using LiveStats.Core.Identity.Data.Settings;

namespace LiveStats.API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration) => configuration.GetConnectionString("DatabaseContextConnection");

        public static JwtSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsConfiguration = configuration.GetSection(nameof(JwtSettings));
            services.Configure<JwtSettings>(appSettingsConfiguration);

            return appSettingsConfiguration.Get<JwtSettings>();
        }
    }
}
