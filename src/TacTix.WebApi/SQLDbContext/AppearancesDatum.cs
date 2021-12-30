using System;
using System.Collections.Generic;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class AppearancesDatum
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public string FirstPosition { get; set; }
        public byte? FirstPositionPlayingTime { get; set; }
        public string SecondPosition { get; set; }
        public byte? SecondPositionPlayingTime { get; set; }
        public bool? StartingEleven { get; set; }
        public byte? SubInMin { get; set; }
        public byte? SubOutMin { get; set; }
        public byte? TotalMinutesPlayed { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
