using LiveStats.Core.Football.Data.Models.Input;
using LiveStats.Core.Football.Data.Models.Output;
using LiveStats.Infrastructure.Data.Models.Football;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Contracts
{
    public interface IFb_PlayerService
    {
        Task<List<Fb_PlayerInTeamReturnModel>> GetPlayersforTeam(string teamId);

        Task<Fb_PlayerDetailsReturnModel> GetPlayerDetails(string playerId);

        Task<bool> CreatePlayer(Fb_PlayerCreateModel data);

        Task<bool> EditPlayer(Fb_PlayerEditModel data);

        Task<bool> MovePlayerToTeam(string playerId, string teamId);

        Task<bool> DeletePlayer(string playerId);
    }
}
