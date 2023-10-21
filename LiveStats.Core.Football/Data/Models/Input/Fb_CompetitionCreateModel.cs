using LiveStats.Core.Football.Data.Models.Output;
using System.ComponentModel.DataAnnotations;

namespace LiveStats.Core.Football.Data.Models.Input
{
    public class Fb_CompetitionCreateModel
    {
        [Required]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public int NationalityId { get; set; }

        public List<Fb_TeamInStandingsModel>? Teams { get; set; }
    }
}
