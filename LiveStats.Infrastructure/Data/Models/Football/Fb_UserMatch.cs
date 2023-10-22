using LiveStats.Infrastructure.Data.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Infrastructure.Data.Models.Football
{
    public class Fb_UserMatch
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Required]
        public string MatchId { get; set; }

        [ForeignKey(nameof(MatchId))]
        public Fb_Match Match { get; set; }
    }
}
