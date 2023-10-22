using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Football.Data.Models.Output
{
    public class Fb_CompetitionLivescoreModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string NationalityName { get; set; }
    }
}
