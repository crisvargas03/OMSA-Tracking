namespace OMSATrackingAPI.DAL.Models
{
    public class FavoriteRoute : BaseEntity<int>
    { 
        public int UserIdentificationCode { get; set; }
        public int IdBus { get; set; }

        // Navigation properties
        public required Bus Bus { get; set; }
    }
}
