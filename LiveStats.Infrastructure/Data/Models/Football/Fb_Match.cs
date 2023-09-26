using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Infrastructure.Data.Models.Football
{
    public class Fb_Match
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public int CompetitionId { get; set; }

        [ForeignKey(nameof(CompetitionId))]
        public Fb_Competition Competition { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [ForeignKey(nameof(HomeTeamId))]
        public Fb_Team HomeTeam { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [ForeignKey(nameof(AwayTeamId))]
        public Fb_Team AwayTeam { get; set; }

        [Required]
        public int HomeScore { get; set; } = 0;

        [Required]
        public int AwayScore { get; set; } = 0;

        [Required]
        public bool InProgress { get; set; } = false;

        [Required]
        public int Minutes { get; set; } = 0;

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        public int StadiumId { get; set; }

        [ForeignKey(nameof(StadiumId))]
        public Fb_Stadium Stadium { get; set; }
    }
}
