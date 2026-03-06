using System.ComponentModel.DataAnnotations;

namespace SimLeagueControlCenter.Dtos
{
    public class CreateSeasonDto
    {
        [Required(ErrorMessage = "Season name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exeed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required")]
        public DateOnly StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateOnly EndDate { get; set; }

        [Required(ErrorMessage = "League ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Leage ID must be greater than 0")]
        public int LeagueId { get; set; }
    }
}