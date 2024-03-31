namespace OMSATrackingAPI.DAL.Models
{
    public class Driver : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IndentificationDocument { get; set; } = string.Empty;
        public int BusId { get; set; }

        // Navigation properties
        public Bus Bus { get; set; } = null!;
    }
}
