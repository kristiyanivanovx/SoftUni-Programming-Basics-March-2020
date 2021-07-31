using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Models
{
    public class Color
    {
        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Team> PrimaryKitTeams { get; set; }

        public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
