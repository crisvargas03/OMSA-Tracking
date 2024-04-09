namespace OMSATrackingAPI.BLL.DTOs
{
    public class InsertBusDto
    {
        public string Name { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string EstimatedArrivalHour { get; set; } = string.Empty;
        public int PassengerLimit { get; set; }
        public int RouteId { get; set; }
        public int StopId { get; set; }
    }
}
