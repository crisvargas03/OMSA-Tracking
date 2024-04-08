using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSATrackingAPI.BLL.DTOs
{
    internal class BusStopDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public int Position { get; set; }
        public int RouteId { get; set; }
    }
}
