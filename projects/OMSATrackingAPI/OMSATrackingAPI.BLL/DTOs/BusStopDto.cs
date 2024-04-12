namespace OMSATrackingAPI.BLL.DTOs
{
    public class BusStopDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }
        public LocationDto Location { get; set; }
        public int RouteId { get; set; }
        public int Position { get; set; }

        public IEnumerable<BusDto> Buses { get; set; }
    }
}
