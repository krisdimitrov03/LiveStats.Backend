using LiveStats.Infrastructure.Data.Models.Football;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Contracts
{
    public interface IFb_CompetitionService
    {
        Task GetAll();

        Task GetByCountry(int countryId);

        Task GetDetails(int id);

        Task GetStandings(int id);


    }
}
