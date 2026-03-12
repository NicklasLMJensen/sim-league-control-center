using SimLeagueControlCenter.Models;

namespace SimleagueControlCenter.Dtos
{
    public class SessionDto
    {
        public int Id { get; set; }
        public SessionType Type { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public int EventId { get; set; }

        public string EventName { get; set; } = string.Empty; 
    }
}