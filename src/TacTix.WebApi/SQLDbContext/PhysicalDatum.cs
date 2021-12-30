using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class PhysicalDatum
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public double? DistanceCoverd { get; set; }
        public double? TopSpeed { get; set; }
        public double? AverageSpeed { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
