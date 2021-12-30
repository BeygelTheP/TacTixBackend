using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class PlayerPosition
    {
        public int PlayerId { get; set; }
        public string MainUnit { get; set; }
        public string SecondaryUnit { get; set; }
        public string MainPosition { get; set; }
        public string SecondaryPosition { get; set; }

        //public Player Player { get; set; }
    }
}
