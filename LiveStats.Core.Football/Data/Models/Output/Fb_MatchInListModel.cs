using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Data.Models.Output
{
    public class Fb_MatchInListModel
    {
        public string Id { get; set; }

        public string DateAndTime { get; set; }

        public string Minutes { get; set; }

        public Fb_TeamInMatchModel HomeTeam { get; set; }

        public Fb_TeamInMatchModel AwayTeam { get; set; }
    }
}
