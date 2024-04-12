using System.Text.Json.Serialization;

namespace OMSATrackingAPI.DAL.Models
{
    public class Route : BaseEntity<int>
    {
        public string Code { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;

        [JsonIgnore]
        // Navigation properties
        public ICollection<Bus> Buses { get; set; } = [];
    }
}
