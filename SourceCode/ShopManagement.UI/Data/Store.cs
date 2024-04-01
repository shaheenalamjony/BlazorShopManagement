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

        public int? TransitDistrictId { get; set; } 
        public District? TransitDistrict { get; set; } 

        public int? NonTransitDistrictId { get; set; } 
        public District? NonTransitDistrict { get; set; } 

        public int? UpazilaId { get; set; } 
        public Upazila? Upazila { get; set; } 

        public bool IsTransit { get; set; }
    }
}
