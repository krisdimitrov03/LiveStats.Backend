namespace LiveStats.Core.Football.Data.Models.Output
{
    public class Fb_TeamInStandingsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        public int GamesPlayed { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }

        public int GoalDifference { get; set; }

        public int Points { get; set; }
    }
}
