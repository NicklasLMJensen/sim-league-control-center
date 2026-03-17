using System.ComponentModel.DataAnnotations;

namespace SimLeagueControlCenter.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Make { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Model { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Class { get; set; }

        [Range(1, 9999)]
        public int? CarNumber { get; set; }
    }
}