using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class Discipline
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int YellowCards { get; set; }
        public bool RedCard { get; set; }
        public bool StraightRed { get; set; }
        public byte? GamesSuspended { get; set; }
        public string FromCompetition { get; set; }
        public DateTime? SuspensionStartDate { get; set; }
        public DateTime? SuspensionEndDate { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
