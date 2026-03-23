using System.ComponentModel.DataAnnotations;

namespace SimLeagueControlCenter.Dtos
{
    public class CreateEntryDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Season ID must be greater than 0")]
        public int SeasonId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Driver ID must be greater than 0")]
        public int DriverId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Team ID must be greater than 0")]
        public int TeamId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Car Id must be greater than 0")]
        public int CarId { get; set; }

        [Range(1, 9999)]
        public int? RaceNumber { get; set; }
    }
}