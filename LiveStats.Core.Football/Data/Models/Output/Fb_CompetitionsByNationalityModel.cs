using LiveStats.Infrastructure.Data.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Data.Models.Output
{
    public class Fb_CompetitionsByNationalityModel
    {
        public Sh_Nationality Nationality { get; set; }

        public List<Fb_CompetitionInListModel> Competitions { get; set; }
    }
}
