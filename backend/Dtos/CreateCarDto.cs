using System.ComponentModel.DataAnnotations;


namespace SimLeagueControlCenter.Dtos
{
    public class CreateCarDto
    {
        [Required(ErrorMessage = "Car Make is required")]
        [StringLength(100, ErrorMessage = "Car Make cannot exceed 100 characters")]
        public string Make { get; set; } = string.Empty;

        [Required(ErrorMessage = "Car Model is required")]
        [StringLength(100, ErrorMessage = "Car Model cannot exceed 100 characters")]
        public string Model { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Class { get; set; }

        [Range(1, 9999)]
        public int? CarNumber { get; set; }
    }
}