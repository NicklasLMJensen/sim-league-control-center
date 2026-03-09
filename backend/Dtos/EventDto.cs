namespace SimleagueControlCenter.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Date { get; set;}
        public string? TrackName { get; set; }
        public int SeasonId { get; set; }
        public string SeasonName { get; set; } = string.Empty;
    }
}