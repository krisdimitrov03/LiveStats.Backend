using LiveStats.Core.Football.Contracts;
using LiveStats.Infrastructure.Data.Models.Football;
using LiveStats.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Services
{
    public class Fb_CompetitionService : IFb_CompetitionService
    {
        private readonly IApplicationDbRepository repo;

        public Fb_CompetitionService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<List<Fb_Competition>> GetAll()
        {
            return await repo.All<Fb_Competition>().ToListAsync();
        }

        public Task GetByCountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public Task GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetStandings(int id)
        {
            throw new NotImplementedException();
        }

        Task IFb_CompetitionService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
