using System.ComponentModel.DataAnnotations;
using SimLeagueControlCenter.Models;


namespace SimleagueControlCenter.Dtos
{
    public class CreateSessionDto
    {
        [Required]
        public SessionType Type { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "EventId must be greater than 0.")]
        public int EventId { get; set;}
    }
}