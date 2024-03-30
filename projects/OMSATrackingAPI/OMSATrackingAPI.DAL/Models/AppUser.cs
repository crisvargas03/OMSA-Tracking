using System.ComponentModel.DataAnnotations;

namespace OMSATrackingAPI.DAL.Models
{
    public class AppUser : BaseEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(25)]
        public string Password { get; set; } = string.Empty;
    }
}
