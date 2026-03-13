using System.Diagnostics.Contracts;

namespace SimleagueControlCenter.Dtos
{
    public class DriverDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Nationality { get; set; }
        public string? IracingId { get; set; }
    }
}