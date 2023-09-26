using LiveStats.Core.Football.Contracts;
using LiveStats.Core.Football.Data.Models.Input;
using LiveStats.Core.Football.Data.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Services
{
    public class Fb_PlayerService : IFb_PlayerService
    {
        public Task<bool> CreatePlayer(Fb_PlayerCreateModel data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlayer(string playerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditPlayer(Fb_PlayerEditModel data)
        {
            throw new NotImplementedException();
        }

        public Task<Fb_PlayerDetailsReturnModel> GetPlayerDetails(string playerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Fb_PlayerInTeamReturnModel>> GetPlayersforTeam(string teamId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MovePlayerToTeam(string playerId, string teamId)
        {
            throw new NotImplementedException();
        }
    }
}
