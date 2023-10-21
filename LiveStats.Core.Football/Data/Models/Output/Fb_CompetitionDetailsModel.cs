namespace LiveStats.Core.Football.Data.Models.Output
{
    public class Fb_CompetitionDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        public string NationalityName { get; set; }

        public string NationalityImageUrl { get; set; }

        public string Season { get; set; }

        public List<Fb_TeamInStandingsModel> Standings { get; set; }
    }
}
