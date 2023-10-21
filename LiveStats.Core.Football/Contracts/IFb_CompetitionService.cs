using LiveStats.Core.Football.Data.Models.Input;
using LiveStats.Core.Football.Data.Models.Output;
using LiveStats.Infrastructure.Data.Models.Football;
using LiveStats.Infrastructure.Data.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Contracts
{
    public interface IFb_CompetitionService
    {
        Task<List<Fb_Competition>> GetAll();

        Task<List<Fb_Competition>> GetByCountry(int countryId);

        Task<List<Fb_CompetitionsByNationalityModel>> GetGroupedByCountry();

        Task<Fb_CompetitionDetailsModel> GetDetails(int id);

        Task<List<Fb_TeamInStandingsModel>> GetStandings(int id);

        Task<(bool, string?)> Create(Fb_CompetitionCreateModel data);

        Task<bool> Update(Fb_CompetitionUpdateModel data);

        Task<bool> Delete(int id);
    }
}
