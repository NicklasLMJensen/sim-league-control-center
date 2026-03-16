using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace SimLeagueControlCenter.Models
{
    public class CreateTeamDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; } = string.Empty;

        [StringLength(100)]
        public string? PrimaryColor { get; set; } = string.Empty;
    }
}