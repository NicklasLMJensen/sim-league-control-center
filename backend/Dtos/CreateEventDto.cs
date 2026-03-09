using System.ComponentModel.DataAnnotations;

namespace SimLeagueControlCenter.Dtos
{
    public class CreateEventDto
    {
        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(100, ErrorMessage = "Event name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateOnly Date { get; set;}

        [StringLength(100)]
        public string TrackName { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "SeasonId must be a positive integer.")]
        public int SeasonId { get; set; }
    }
}
