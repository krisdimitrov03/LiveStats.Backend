using LiveStats.Infrastructure.Data;
using LiveStats.Infrastructure.Data.Models.Football;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Managers
{
    public static class MatchGenerator
    {
        private static Random rand = new Random();
        private static int[] countryIds = { 49, 56, 60, 68, 80, 94, 110 };
        private static int[] scoreRange = { 0, 10 };

        public static IApplicationBuilder GenerateRandomMatches(this IApplicationBuilder builder, int count)
        {
            for (int i = 0; i < count; i++)
                CreateRandomMatch(builder, rand.Next(0, 1) == 0 ? false : true);

            return builder;
        }

        private static void CreateRandomMatch(IApplicationBuilder builder, bool live)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                int nationalityId = countryIds[rand.Next(0, countryIds.Length - 1)];

                int[] competitionIds = context
                    .Set<Fb_Competition>()
                    .Where(c => c.NationalityId == nationalityId)
                    .Select(c => c.Id)
                    .ToArray();

                int competitionId = competitionIds[rand.Next(0, competitionIds.Length - 1)];

                int[] teamIds = context
                    .Set<Fb_CompetitionTeam>()
                    .Where(ct => ct.CompetitionId == competitionId)
                    .Select(ct => ct.TeamId)
                    .ToArray();

                int homeTeamId = -1;
                int awayTeamId = -1;

                while (homeTeamId == awayTeamId)
                {
                    homeTeamId = teamIds[rand.Next(0, teamIds.Length - 1)];
                    awayTeamId = teamIds[rand.Next(0, teamIds.Length - 1)];
                }

                var dateTime = DateTime.Now.AddDays(rand.Next(50));

                Fb_Match result = new Fb_Match()
                {
                    InProgress = dateTime == DateTime.Now,
                    DateAndTime = dateTime,
                    HomeTeamId = homeTeamId,
                    AwayTeamId = awayTeamId,
                    CompetitionId = competitionId,
                    HomeScore = rand.Next(scoreRange[0], scoreRange[1]),
                    AwayScore = rand.Next(scoreRange[0], scoreRange[1]),
                    Minutes = live == false ? 0 : rand.Next(2, 90),
                };

                result.InProgress = live;

                result.StadiumId = context
                    .Set<Fb_Team>()
                    .First(t => t.Id == homeTeamId)
                    .StadiumId;

                context.Set<Fb_Match>()
                    .Add(result);

                context.SaveChanges();
            }
        }
    }
}
