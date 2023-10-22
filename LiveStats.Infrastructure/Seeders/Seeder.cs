using LiveStats.Infrastructure.Data;
using LiveStats.Infrastructure.Data.Models.Football;
using LiveStats.Infrastructure.Data.Models.Identity;
using LiveStats.Infrastructure.Data.Models.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Infrastructure.Seeders
{
    public static class Seeder
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                context.Database.EnsureCreated();

                AddData<ApplicationUser>(context, SeedDataConstants.Identity, SeedDataConstants.IdentityConstants.Users);
                AddData<IdentityRole>(context, SeedDataConstants.Identity, SeedDataConstants.IdentityConstants.Roles);
                AddData<IdentityUserRole<string>>(context, SeedDataConstants.Identity, SeedDataConstants.IdentityConstants.UsersRoles);

                AddData<Sh_Nationality>(context, SeedDataConstants.Shared, SeedDataConstants.Sh_Constants.Nationalities);

                AddData<Fb_PositionType>(context, SeedDataConstants.Football, SeedDataConstants.Fb_Constants.PositionTypes);
                AddData<Fb_Position>(context, SeedDataConstants.Football, SeedDataConstants.Fb_Constants.Positions);
                AddData<Fb_Competition>(context, SeedDataConstants.Football, SeedDataConstants.Fb_Constants.Competitions);
                AddData<Fb_Team>(context, SeedDataConstants.Football, SeedDataConstants.Fb_Constants.Teams);
            }

            return builder;
        }

        private static void AddData<T>(DatabaseContext context, string category, string fileName)
            where T : class
        {
            if (!context.Set<T>().Any())
            {
                var data = new List<T>();

                using (var reader = new StreamReader(string.Format(SeedDataConstants.Path, category, fileName)))
                {
                    data = JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());
                }

                context.Set<T>().AddRange(data);
                context.SaveChanges();
            }
        }
    }
}