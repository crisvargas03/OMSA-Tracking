namespace OMSATrackingAPI.DAL.Models
{
    public class AddFavoriteRequest
    {
        public required int UserIdentificationCode { get; set; }
        public required int IdBus { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
