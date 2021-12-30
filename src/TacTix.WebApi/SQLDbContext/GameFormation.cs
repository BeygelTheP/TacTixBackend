using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class GameFormation
    {
        public int GameId { get; set; }
        public int FormationId { get; set; }
        public byte? MinutesPlayed { get; set; }
        public byte? GoalsFor { get; set; }
        public byte? GoalsAgainst { get; set; }

        public virtual Formation Formation { get; set; }
        public virtual Game Game { get; set; }
    }
}
