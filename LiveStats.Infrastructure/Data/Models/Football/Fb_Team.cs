using LiveStats.Infrastructure.Data.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveStats.Infrastructure.Data.Models.Football
{
    public class Fb_Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int NationalityId { get; set; }

        [ForeignKey(nameof(NationalityId))]
        public Sh_Nationality Nationality { get; set; }

        [Required]
        public int StadiumId { get; set; }

        [ForeignKey(nameof(StadiumId))]
        public Fb_Stadium Stadium { get; set; }

        public string? ImageUrl { get; set; }

        public IList<Fb_CompetitionTeam> CompetitionTeams { get; set; } = new List<Fb_CompetitionTeam>();

        public IList<Fb_Match> HomeMatches { get; set; } = new List<Fb_Match>();
        public IList<Fb_Match> AwayMatches { get; set; } = new List<Fb_Match>();
    }
}
