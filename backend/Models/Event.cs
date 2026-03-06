using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimLeagueControlCenter.Models;


namespace SimleagueControlCenter.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required, StringLength(100, ErrorMessage = "Event name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required")]
        public DateOnly Date { get; set; }

        [StringLength(100)]
        public string? TrackName { get; set; }

        [Required(ErrorMessage = "Season ID is required")]
        public int SeasonId { get; set; }

        [ForeignKey("SeasonId")]
        public Season Season { get; set; } = null!;
    }
}