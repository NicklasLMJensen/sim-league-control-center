using System.ComponentModel.DataAnnotations;

namespace SimLeagueControlCenter.Dtos
{
    public class CreateDriverDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100, ErrorMessage = "Last Name connot exceed 100 characters")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Nationality { get; set; }

        [StringLength(50)]
        public string? IracingId { get; set; }
    }
}