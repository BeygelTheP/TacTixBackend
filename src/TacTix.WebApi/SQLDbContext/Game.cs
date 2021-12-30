using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class Game
    {
        public Game()
        {
            AppearancesData = new HashSet<AppearancesDatum>();
            Disciplines = new HashSet<Discipline>();
            GameFormations = new HashSet<GameFormation>();
            PerformanceData = new HashSet<PerformanceDatum>();
            PhysicalData = new HashSet<PhysicalDatum>();
        }

        public int GameId { get; set; }
        public DateTime GameDate { get; set; }
        public string Season { get; set; }
        public string Opponent { get; set; }
        public string Competition { get; set; }
        public byte GoalsFor { get; set; }
        public byte GoalsAgainst { get; set; }
        public string LineUpPicturePath { get; set; }
        public string Result { get; set; }

        public virtual ICollection<AppearancesDatum> AppearancesData { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<GameFormation> GameFormations { get; set; }
        public virtual ICollection<PerformanceDatum> PerformanceData { get; set; }
        public virtual ICollection<PhysicalDatum> PhysicalData { get; set; }
    }
}
