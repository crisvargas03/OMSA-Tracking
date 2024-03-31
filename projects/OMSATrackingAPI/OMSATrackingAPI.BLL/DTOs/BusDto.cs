namespace OMSATrackingAPI.BLL.DTOs
{
    public class BusDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public TimeOnly EstimatedArrivalHour { get; set; }
        public int PassengerLimit { get; set; }
        public int RouteId { get; set; }
    }
}
