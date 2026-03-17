using System.Diagnostics.Contracts;

namespace SimleagueControlCenter.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } =string.Empty;
        public string? Class { get; set; }
        public int? CarNumber {get; set; }
    }
}