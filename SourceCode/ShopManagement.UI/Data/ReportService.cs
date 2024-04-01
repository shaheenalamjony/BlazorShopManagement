// ReportService.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopManagement.UI.Data;

namespace ShopManagement.UI.Services
{
    public class ReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DistrictUpazilaReport>> GenerateDistrictUpazilaReportAsync()
        {
            var report = await _context.Districts
                .Select(district => new DistrictUpazilaReport
                {
                    DistrictName = district.Name,
                    Upazilas = district.Upazilas.Select(upazila => upazila.Name).ToList()
                })
                .ToListAsync();

            return report;
        }
    }

    public class DistrictUpazilaReport
    {
        public string DistrictName { get; set; }
        public List<string> Upazilas { get; set; }
    }
}