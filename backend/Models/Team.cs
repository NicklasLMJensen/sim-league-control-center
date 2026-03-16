using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace SimLeagueControlCenter.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set;} = string.Empty;

        [StringLength(500)]
        public string? Description {get; set; } = string.Empty;

        [StringLength(100)]
        public string? PrimaryColor { get; set; } = string.Empty;
    }
}