using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.UI.Data
{
    public class Upazila
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? DistrictId { get; set; } // Allow null for optional relationship
        public District District { get; set; } // Navigatio
    }
}
