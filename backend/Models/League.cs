using System.ComponentModel.DataAnnotations;

namespace SimLeagueControlCenter.Models
{
    public class League
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? description { get; set; }
    }
}