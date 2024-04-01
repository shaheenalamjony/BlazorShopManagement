using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.UI.Data
{
    public class Store
    {
        [Key]
        public int Id { get; set; }

        public int RegionalOfficeEnumId { get; set; }
        public string RegionalStoreName { get; set; }

        public int? TransitDistrictId { get; set; } // Nullable for optional relationship
        public District? TransitDistrict { get; set; } // Navigation property (one-to-many with District)

        public int? NonTransitDistrictId { get; set; } // Nullable for optional relationship
        public District? NonTransitDistrict { get; set; } // Navigation property (one-to-many with District)

        public int? UpazilaId { get; set; } // Nullable for optional relationship
        public Upazila? Upazila { get; set; } // Navigation property (one-to-many with Upazila)

        public bool IsTransit { get; set; }
    }
}
