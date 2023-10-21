using LiveStats.Core.Football.Contracts;
using LiveStats.Core.Football.Data.Models.Input;
using LiveStats.Core.Football.Data.Models.Output;
using LiveStats.Core.Football.Managers;
using LiveStats.Infrastructure.Data.Models.Football;
using LiveStats.Infrastructure.Data.Models.Shared;
using LiveStats.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiveStats.Core.Football.Services
{
    public class Fb_CompetitionService : IFb_CompetitionService
    {
        private readonly IApplicationDbRepository repo;

        public Fb_CompetitionService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<(bool, string?)> Create(Fb_CompetitionCreateModel data)
        {
            var (status, error) = DataValidator.Validate(data);

            if (!status)
                return (false, error);

            Fb_Competition competition = new Fb_Competition
            {
                Name = data.Name,
                ImageUrl = data.ImageUrl,
                NationalityId = data.NationalityId,
            };

            await repo.AddAsync(competition);
            await repo.SaveChangesAsync();

            if (data.Teams == null)
                return (true, null);

            List<Fb_CompetitionTeam> competitionTeams = data.Teams.Select(t => new Fb_CompetitionTeam
            {
                Competition = competition,
                TeamId = t.Id,
                GamesPlayed = t.GamesPlayed,
                Wins = t.Wins,
                Draws = t.Draws,
                Losses = t.Losses,
                GoalDifference = t.GoalDifference,
                Points = t.Points
            }).ToList();

            await repo.AddRangeAsync(competitionTeams);
            await repo.SaveChangesAsync();

            return (true, null);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                List<Fb_CompetitionTeam> competitionTeams = await repo
                .All<Fb_CompetitionTeam>()
                .Where(ct => ct.CompetitionId == id)
                .ToListAsync();

                repo.DeleteRange(competitionTeams);
                await repo.SaveChangesAsync();

                await repo.DeleteAsync<Fb_Competition>(id);
                await repo.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Fb_Competition>> GetAll()
        {
            return await repo
                .All<Fb_Competition>()
                .ToListAsync();
        }

        public async Task<List<Fb_Competition>> GetByCountry(int countryId)
        {
            return await repo
                .All<Fb_Competition>()
                .Where(c => c.NationalityId == countryId)
                .ToListAsync();
        }

        public async Task<Fb_CompetitionDetailsModel?> GetDetails(int id)
        {
            var competition = await repo
                .All<Fb_Competition>(c => c.Id == id)
                .Include(c => c.Nationality)
                .FirstOrDefaultAsync();

            if (competition == null)
                return null;

            var standings = await GetStandings(id);

            return new Fb_CompetitionDetailsModel
            {
                Id = competition.Id,
                Name = competition.Name,
                ImageUrl = competition.ImageUrl,
                NationalityName = competition.Nationality.Name,
                NationalityImageUrl = competition.Nationality.ImageUrl,
                Season = "23/24",
                Standings = standings
            };
        }

        public async Task<List<Fb_CompetitionsByNationalityModel>> GetGroupedByCountry()
        {
            var result = new List<Fb_CompetitionsByNationalityModel>();

            var competitions = await repo.All<Fb_Competition>()
                .Include(c => c.Nationality)
                .ToListAsync();

            foreach (var cmp in competitions)
            {
                var curr = new Fb_CompetitionInListModel
                {
                    Id = cmp.Id,
                    Name = cmp.Name,
                    ImageUrl = cmp.ImageUrl
                };

                if (result.Any(c => c.Nationality == cmp.Nationality))
                {
                    result.First(c => c.Nationality == cmp.Nationality).Competitions.Add(curr);
                }
                else
                {
                    result.Add(new Fb_CompetitionsByNationalityModel {
                        Nationality = cmp.Nationality,
                        Competitions = new List<Fb_CompetitionInListModel> { curr }
                    });
                }
            }

            return result;
        }

        public async Task<List<Fb_TeamInStandingsModel>> GetStandings(int id)
        {
            return await repo
                .All<Fb_CompetitionTeam>()
                .Where(ct => ct.CompetitionId == id)
                .Include(ct => ct.Team)
                .Select(ct => new Fb_TeamInStandingsModel
                {
                    Id = ct.Team.Id,
                    Name = ct.Team.Name,
                    ImageUrl = ct.Team.ImageUrl,
                    GamesPlayed = ct.GamesPlayed,
                    Wins = ct.Wins,
                    Draws = ct.Draws,
                    Losses = ct.Losses,
                    GoalDifference = ct.GoalDifference,
                    Points = ct.Points
                })
                .OrderByDescending(t => t.Points)
                .ToListAsync();
        }

        public Task<bool> Update(Fb_CompetitionUpdateModel data)
        {
            throw new NotImplementedException();
        }
    }
}
