﻿using System.Collections.Generic;

namespace P03_FootballBetting.Models
{
    public class Country
    {
        public string CountryId { get; set; }

        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
