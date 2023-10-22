using LiveStats.Core.Football.Data.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Contracts
{
    public interface IFb_MatchService
    {
        Task<List<Fb_MatchesByCompetitionModel>> GetAll();
        Task<List<Fb_MatchesByCompetitionModel>> GetLivescore();
        Task<List<Fb_MatchesByCompetitionModel>> GetForTeam(int teamId);

        //Task<Fb_MatchDetailsModel> GetDetails(string id);
    }
}
