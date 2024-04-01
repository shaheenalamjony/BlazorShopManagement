using System.ComponentModel.DataAnnotations;

namespace ShopManagement.UI.Data
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Upazila> Upazilas { get; set; } // Navigation property (one-to-many with Upazila)

        public ICollection<Store> TransitStores { get; set; } // Navigation property
        public ICollection<Store> NonTransitStores { get; set; } // Navigation propertyransit District
    }
}
