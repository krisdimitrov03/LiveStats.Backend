using LiveStats.Core.Shared.Contracts;
using LiveStats.Core.Shared.Data.Models;
using LiveStats.Infrastructure.Data.Models.Shared;
using LiveStats.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiveStats.Core.Shared.Services
{
    public class Sh_NationalityService : ISh_NationalityService
    {
        private readonly IApplicationDbRepository repo;

        public Sh_NationalityService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<(bool, string?)> Create(Sh_NationalityCreateModel data)
        {
            try
            {
                Sh_Nationality obj = new Sh_Nationality
                {
                    Name = data.Name,
                    ImageUrl = data.ImageUrl
                };

                await repo.AddAsync(obj);
                await repo.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception)
            {
                return (false, null);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var obj = await repo.GetByIdAsync<Sh_Nationality>(id);

                if (obj == null)
                    return false;

                await repo.DeleteAsync<Sh_Nationality>(id);
                await repo.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Sh_Nationality>> GetAll()
        {
            return await repo.All<Sh_Nationality>()
                .ToListAsync();
        }

        public async Task<Sh_Nationality> GetById(int id)
        {
            return await repo.GetByIdAsync<Sh_Nationality>(id);
        }

        public async Task<(bool, string?)> Update(int id, Sh_NationalityUpdateModel data)
        {
            try
            {
                var obj = await repo.GetByIdAsync<Sh_Nationality>(id);

                if (obj == null)
                    return (false, "Nationality not found");

                if(data.Name != null)
                    obj.Name = data.Name;

                if(data.ImageUrl != null)
                    obj.ImageUrl = data.ImageUrl;

                repo.Update(obj);
                await repo.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception)
            {
                return (false, null);
            }
        }
    }
}
