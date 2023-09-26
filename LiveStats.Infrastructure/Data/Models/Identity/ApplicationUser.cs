using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LiveStats.Infrastructure.Data.Models.Identity;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string? ImageUrl { get; set; }
}

