using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class Formation
    {
        public Formation()
        {
            GameFormations = new HashSet<GameFormation>();
        }

        public int FormationId { get; set; }
        public string TacticalFormation { get; set; }
        public string FormationStyle { get; set; }

        public virtual ICollection<GameFormation> GameFormations { get; set; }
    }
}
