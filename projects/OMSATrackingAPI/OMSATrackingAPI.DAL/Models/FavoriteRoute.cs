using System.Text.Json.Serialization;

namespace OMSATrackingAPI.DAL.Models
{
    public class FavoriteRoute : BaseEntity<int>
    {
        public int UserIdentificationCode { get; set; }
        public int IdBus { get; set; }

        [JsonIgnore]
        // Navigation properties
        public Bus? Bus { get; set; } = null!;
    }
}
