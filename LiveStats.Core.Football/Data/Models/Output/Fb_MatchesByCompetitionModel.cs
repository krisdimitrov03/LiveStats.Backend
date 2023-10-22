using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Data.Models.Output
{
    public class Fb_MatchesByCompetitionModel
    {
        public Fb_CompetitionLivescoreModel Competition { get; set; }

        public List<Fb_MatchInListModel> Matches { get; set; }
    }
}
