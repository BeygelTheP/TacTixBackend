using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class Player
    {
        public Player()
        {
            AppearancesData = new HashSet<AppearancesDatum>();
            Disciplines = new HashSet<Discipline>();
            Medicals = new HashSet<Medical>();
            PerformanceData = new HashSet<PerformanceDatum>();
            PhysicalData = new HashSet<PhysicalDatum>();
        }

        public int PlayerId { get; set; }
        public byte PlayerNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double? PlayerHight { get; set; }
        public string PhoneNo { get; set; }

        public PlayerPosition PlayerPosition { get; set; }
        public virtual ICollection<AppearancesDatum> AppearancesData { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<Medical> Medicals { get; set; }
        public virtual ICollection<PerformanceDatum> PerformanceData { get; set; }
        public virtual ICollection<PhysicalDatum> PhysicalData { get; set; }
    }
}
