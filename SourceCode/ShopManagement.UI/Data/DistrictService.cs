using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopManagement.UI.Data
{
    public class DistrictService
    {
        private readonly ApplicationDbContext _context;

        public DistrictService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<District>> GetDistrictsAsync()
        {
            try
            {
                return await _context.Districts.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception, log it, or throw it further
                // For simplicity, rethrowing the exception here
                throw ex;
            }
        }

        public async Task<District> GetDistrictByIdAsync(int id)
        {
            try
            {
                return await _context.Districts.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateDistrictAsync(District district)
        {
            try
            {
                _context.Districts.Add(district);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateDistrictAsync(District district)
        {
            try
            {
                _context.Entry(district).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteDistrictAsync(int id)
        {
            try
            {
                var district = await _context.Districts.FindAsync(id);
                if (district != null)
                {
                    _context.Districts.Remove(district);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
