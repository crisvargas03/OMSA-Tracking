namespace OMSATrackingAPI.BLL.DTOs
{
    public class UpdateBusDto
    {
        public string Name { get; set; } 
        public string Latitude { get; set; } 
        public string Longitude { get; set; } 
        public string Plate { get; set; }
        public string EstimatedArrivalHour { get; set; } 
        public int PassengerLimit { get; set; } 
        public int RouteId { get; set; }
        public int StopId { get; set; }
    }
}
