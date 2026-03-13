using System.ComponentModel.DataAnnotations;

namespace SimLeagueControlCenter.Models
{
    public class Driver
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Nationality { get; set; } = string.Empty;

        [StringLength(100)]
        public string? IracingId { get; set; } = string.Empty;
    }
}