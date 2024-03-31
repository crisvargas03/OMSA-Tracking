using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.BLL.DTOs
{
    public class RouteDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;

        // Navigation properties
        public List<BusDto> Buses { get; set; } = new();
    }
}
