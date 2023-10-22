using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Infrastructure.Data.Models.Football
{
    public class Fb_CompetitionTeam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompetitionId { get; set; }

        [ForeignKey(nameof(CompetitionId))]
        public Fb_Competition Competition { get; set; }

        [Required]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Fb_Team Team { get; set; }

        [Required]
        public int GamesPlayed { get; set; } = 0;

        [Required]
        public int Wins { get; set; } = 0;

        [Required]
        public int Draws { get; set; } = 0;

        [Required]
        public int Losses { get; set; } = 0;

        [Required]
        public int GoalDifference { get; set; } = 0;

        [Required]
        public int Points { get; set; } = 0;
    }
}
