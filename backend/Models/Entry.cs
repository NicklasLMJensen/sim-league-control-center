using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimLeagueControlCenter.Models;

namespace SimLeagueControlcenter.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public int SeasonId { get; set; }

        [ForeignKey("SeasonId")]
        public Season Season { get; set; } = null!;

        [Required]
        public int DriverId { get; set; }

        [ForeignKey("DriverId")]
        public Driver Driver { get; set; } = null!;

        [Required]
        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; } = null!;

        [Required]
        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public Car Car { get; set; } = null!;

        [Range(1, 9999)]
        public int? RaceNumber { get; set; }


    }
}