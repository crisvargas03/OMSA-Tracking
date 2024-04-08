namespace OMSATrackingAPI.DAL.Models
{
    public class BusStop : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public int Position { get; set; } 
        public int RouteId { get; set; }

        // Navigation properties
        public ICollection<Bus> Buses { get; set; } = new List<Bus>();
        public Route Route { get; set; }
    }
}
