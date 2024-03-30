namespace OMSATrackingAPI.DAL.Models
{
    public class Bus : BaseEntity<int>
    { 
        public string Name { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public TimeOnly EstimatedArrivalHour { get; set; }
        public int PassengerLimit { get; set; }
        public int RouteId { get; set; }

        // Navigation properties
        public required Route Route { get; set; }
        public required FavoriteRoute FavoriteRoute { get; set; }
        public required Driver Driver { get; set; }
    }
}
