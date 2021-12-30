using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class Medical
    {
        public int InjuryId { get; set; }
        public int? PlayerId { get; set; }
        public string InjuryType { get; set; }
        public DateTime DateOfInjury { get; set; }
        public int? EstimateRecoveryDurationInDays { get; set; }
        public DateTime? EstimateReturnDate { get; set; }
        public DateTime ReturnDateInPractice { get; set; }

        public virtual Player Player { get; set; }
    }
}
