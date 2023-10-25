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
        /// <summary>
        /// Gets all competitions from the database
        /// </summary>
        /// <returns>List of competition entities</returns>
        Task<List<Fb_Competition>> GetAll();

        /// <summary>
        /// Gets all competitions for the given country
        /// </summary>
        /// <param name="countryId">The country identificator</param>
        /// <returns>List of competition entities</returns>
        Task<List<Fb_Competition>> GetByCountry(int countryId);

        /// <summary>
        /// Gets all the competitions grouped by nationality
        /// </summary>
        /// <returns></returns>
        Task<List<Fb_CompetitionsByNationalityModel>> GetGroupedByCountry();

        /// <summary>
        /// Gets details for country
        /// </summary>
        /// <param name="id">The competition identificator</param>
        /// <returns>Country details model</returns>
        Task<Fb_CompetitionDetailsModel> GetDetails(int id);

        Task<List<Fb_TeamInStandingsModel>> GetStandings(int id);

        Task<(bool, string?)> Create(Fb_CompetitionCreateModel data);

        Task<bool> Update(Fb_CompetitionUpdateModel data);

        Task<bool> Delete(int id);
    }
}
