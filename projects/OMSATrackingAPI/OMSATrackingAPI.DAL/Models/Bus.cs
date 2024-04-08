namespace OMSATrackingAPI.DAL.Models
{
    public class Bus : BaseEntity<int>
    { 
        public string Name { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string EstimatedArrivalHour { get; set; } = string.Empty;
        public int PassengerLimit { get; set; }
        public int RouteId { get; set; }
        public int StopId { get; set; }

        // Navigation properties
        public Route Route { get; set; } = null!;
        public BusStop Stop { get; set; } = null!;
        public FavoriteRoute FavoriteRoute { get; set; } = null!;
        public Driver Driver { get; set; } = null!;
    }
}
