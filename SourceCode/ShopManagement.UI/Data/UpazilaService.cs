using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopManagement.UI.Data
{
    public class UpazilaService
    {
        private readonly ApplicationDbContext _context;

        public UpazilaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Upazila>> GetUpazilasAsync()
        {
            try
            {
                return await _context.Upazilas.ToListAsync();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error in GetUpazilasAsync: {ex.Message}");
                throw; 
            }
        }

        public async Task<Upazila> GetUpazilaByIdAsync(int id)
        {
            try
            {
                return await _context.Upazilas.FindAsync(id);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error in GetUpazilaByIdAsync: {ex.Message}");
                throw; 
            }
        }

        public async Task CreateUpazilaAsync(Upazila upazila)
        {
            try
            {
                _context.Upazilas.Add(upazila);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error in CreateUpazilaAsync: {ex.Message}");
                throw; 
            }
        }

        public async Task UpdateUpazilaAsync(Upazila upazila)
        {
            try
            {
                _context.Entry(upazila).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error in UpdateUpazilaAsync: {ex.Message}");
                throw; 
            }
        }

        public async Task DeleteUpazilaAsync(int id)
        {
            try
            {
                var upazila = await _context.Upazilas.FindAsync(id);
                if (upazila != null)
                {
                    _context.Upazilas.Remove(upazila);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error in DeleteUpazilaAsync: {ex.Message}");
                throw;
            }

        }
        public Task<List<Upazila>> GetUpazilasByDistrictIdAsync(int districtId)
        {
            
            List<Upazila> upazilas = new List<Upazila>();

            
            return Task.FromResult(upazilas);
        }
    }
}
