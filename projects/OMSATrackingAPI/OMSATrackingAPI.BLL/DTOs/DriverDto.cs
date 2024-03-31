namespace OMSATrackingAPI.BLL.DTOs
{
    public class DriverDto
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IndentificationDocument { get; set; } = string.Empty;
        public int BusId { get; set; }
    }
}
