using LiveStats.Core.Football.Contracts;
using LiveStats.Core.Football.Data.Models.Output;
using LiveStats.Infrastructure.Data.Models.Football;
using LiveStats.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Services
{
    public class Fb_MatchService : IFb_MatchService
    {
        private readonly IApplicationDbRepository repo;

        public Fb_MatchService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<Fb_MatchesByCompetitionModel>> GetAll()
        {
            var result = new List<Fb_MatchesByCompetitionModel>();

            var matches = await repo.All<Fb_Match>()
                .Include(c => c.HomeTeam)
                .Include(c => c.AwayTeam)
                .Include(c => c.Competition)
                .ThenInclude(c => c.Nationality)
                .ToListAsync();

            foreach (var match in matches)
            {
                var curr = new Fb_MatchInListModel
                {
                    Id = match.Id,
                    DateAndTime = match.DateAndTime.ToString("dd.MM.yyyy, HH:mm"),
                    Minutes = match.Minutes.ToString(),
                    HomeTeam = new Fb_TeamInMatchModel
                    {
                        Id = match.HomeTeamId,
                        Name = match.HomeTeam.Name,
                        ImageUrl = match.HomeTeam.ImageUrl,
                        Goals = match.HomeScore.ToString()
                    },
                    AwayTeam = new Fb_TeamInMatchModel
                    {
                        Id = match.AwayTeamId,
                        Name = match.AwayTeam.Name,
                        ImageUrl = match.AwayTeam.ImageUrl,
                        Goals = match.AwayScore.ToString()
                    }
                };

                if (result.Any(c => c.Competition.Id == match.CompetitionId))
                {
                    result.First(c => c.Competition.Id == match.CompetitionId).Matches.Add(curr);
                }
                else
                {
                    result.Add(new Fb_MatchesByCompetitionModel
                    {
                        Competition = new Fb_CompetitionLivescoreModel 
                        { 
                            Id = match.CompetitionId, 
                            Name = match.Competition.Name, 
                            ImageUrl = match.Competition.ImageUrl,
                            NationalityName = match.Competition.Nationality.Name
                        },
                        Matches = new List<Fb_MatchInListModel> { curr }
                    });
                }
            }

            return result;
        }

        public Task<List<Fb_MatchesByCompetitionModel>> GetForTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Fb_MatchesByCompetitionModel>> GetLivescore()
        {
            throw new NotImplementedException();
        }
    }
}
