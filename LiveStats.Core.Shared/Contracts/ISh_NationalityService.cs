using LiveStats.Core.Shared.Data.Models;
using LiveStats.Infrastructure.Data.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Shared.Contracts
{
    public interface ISh_NationalityService
    {
        Task<Sh_Nationality> GetById(int id);

        Task<List<Sh_Nationality>> GetAll();

        Task<(bool, string?)> Create(Sh_NationalityCreateModel data);

        Task<(bool, string?)> Update(int id, Sh_NationalityUpdateModel data);

        Task<bool> Delete(int id);
    }
}
