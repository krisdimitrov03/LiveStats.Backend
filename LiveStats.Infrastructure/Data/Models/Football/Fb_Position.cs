using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveStats.Infrastructure.Data.Models.Football
{
    public class Fb_Position
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PositionTypeId { get; set; }

        [ForeignKey(nameof(PositionTypeId))]
        public Fb_PositionType PositionType { get; set; }
    }
}
