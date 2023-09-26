using LiveStats.Infrastructure.Data.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Infrastructure.Data.Models.Football
{
    public class Fb_Competition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int NationalityId { get; set; }

        [ForeignKey(nameof(NationalityId))]
        public Sh_Nationality Nationality { get; set; }

        public string? ImageUrl { get; set; }
    }
}
