using LiveStats.Infrastructure.Data.Common;

namespace LiveStats.Infrastructure.Data.Repositories
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(DatabaseContext context)
        {
            this.Context = context;
        }
    }
}
