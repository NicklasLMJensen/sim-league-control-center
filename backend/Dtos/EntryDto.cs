namespace SimLeagueControlCenter
{
    public class EntryDto
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public string SeasonName { get; set; } = string.Empty;
        public int DriverId { get; set; }
        public string DriverFirstName { get; set; } = string.Empty;
        public string DriverLastName { get; set; } = string.Empty;
        public int TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public int CarId { get; set; } 
        public string CarMake { get; set; } = string.Empty;
        public string CarModel { get; set; } = string.Empty;
        public int? RaceNumber { get; set; }
    }
}