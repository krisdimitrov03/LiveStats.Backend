namespace LiveStats.Core.Identity.Data.Models.Output
{
    public class RegisterReturnModel
    {
        public bool Success { get; set; }

        public Dictionary<string, List<string>>? Errors { get; set; }
    }
}
