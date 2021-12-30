using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class PerformanceDatum
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public byte? Goals { get; set; }
        public string GoalsMin { get; set; }
        public byte? Assists { get; set; }
        public string AssistsMin { get; set; }
        public byte? TotalShots { get; set; }
        public byte? ShotsOnTarget { get; set; }
        public short? TotalPasses { get; set; }
        public short? KeyPasses { get; set; }
        public byte? Tackels { get; set; }
        public byte? TackelsWon { get; set; }
        public double? WeightedScore { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
