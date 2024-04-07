namespace OMSATrackingAPI.DAL.Models
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
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
