using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimLeagueControlCenter.Models
{
    public class Season
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; } = string.Empty;

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        [Required]
        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public League League { get; set; } = null!;
    }
}