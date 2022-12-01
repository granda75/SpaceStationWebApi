namespace SpaceStationWebApi.Models
{
    public class SpaceStationLocation
    {
        public string? Message { get; set; }
        public long Timestamp { get; set; }
        public IssPosition? iss_position { get; set; }
    }
}
