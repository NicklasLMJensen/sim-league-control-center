namespace SimLeagueControlCenter.Dtos
{
    public class SeasonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int LeagueId { get; set; }
        public string LeagueName { get; set; } = string.Empty;
    }
}