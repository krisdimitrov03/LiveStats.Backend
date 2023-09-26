using LiveStats.Infrastructure.Data.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveStats.Infrastructure.Data.Models.Football
{
    public class Fb_Player
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int NationalityId { get; set; }

        [ForeignKey(nameof(NationalityId))]
        public Sh_Nationality Nationality { get; set; }

        [Required]
        public int PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public Fb_Position Position { get; set; }

        [Required]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Fb_Team Team { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
