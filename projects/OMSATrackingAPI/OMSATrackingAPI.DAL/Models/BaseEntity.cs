using System.Text.Json.Serialization;

namespace OMSATrackingAPI.DAL.Models
{
    public class BaseEntity<T> where T : struct
    {
        [JsonIgnore]
        public T Id { get; set; }
        public string CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime? ModificationDate { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreatedBy = "API OMSA";
            CreationDate = DateTime.UtcNow;
            IsDeleted = false;
            
            ModificationDate = null;
        }
    }
}
