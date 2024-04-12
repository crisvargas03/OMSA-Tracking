namespace OMSATrackingAPI.DAL.Models
{
    public class FavoriteBusStop : BaseEntity<int>
    {
        public int Id { get; set; }

        public int BusStopId { get; set; }


        // Navigation properties
        public BusStop BusStop { get; set; }
    }
}