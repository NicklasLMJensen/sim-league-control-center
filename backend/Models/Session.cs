using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimLeagueControlCenter.Models;


namespace SimleagueControlCenter.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        public SessionType Type { get; set; }

        [Required]
        public DateTime StartTime { get; set;}

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; } = null!;


    }
}