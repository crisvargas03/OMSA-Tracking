namespace OMSATrackingAPI.BLL.DTOs
{
    public class FavoriteDto
    {
        public int UserIdentificationCode { get; set; }
        public int IdBus { get; set; }

        // Navigation properties
        public BusDto Bus { get; set; } = null!;
    }
}
