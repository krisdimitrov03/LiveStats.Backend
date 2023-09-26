using LiveStats.Core.Football.Contracts;
using LiveStats.Core.Football.Services;
using LiveStats.Core.Identity.Contracts;
using LiveStats.Core.Identity.Data.Settings;
using LiveStats.Core.Identity.Services;
using LiveStats.Infrastructure.Data;
using LiveStats.Infrastructure.Data.Models.Identity;
using LiveStats.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LiveStats.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserDefinedServices(this IServiceCollection services)
        => services
            .AddScoped<IApplicationDbRepository, ApplicationDbRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IJwtService, JwtService>()
            .AddScoped<IFb_CompetitionService, Fb_CompetitionService>();

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }
    }
}
