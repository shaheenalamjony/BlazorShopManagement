// StoreService.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.UI.Data
{
    public class StoreService
    {
        private readonly ApplicationDbContext _context;

        public StoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<List<Store>> GetStoresAsync()
        //{
        //    return await _context.Store
        //        //.Include(x => x.RegionalOfficeEnumId)
        //        //.Include(x => x.NonTransitDistrictId)
        //        //.Include(x => x.UpazilaId)
        //        .ToListAsync();


        //}
        public async Task<List<Store>> GetStoresAsync()
        {
            return await _context.Store
                .Include(x => x.TransitDistrict)
                .Include(x => x.NonTransitDistrict)
                .Include(x => x.Upazila)
                .ToListAsync();
        }
        public async Task<Store> GetStoreByIdAsync(int id)
        {
            return await _context.Store.FindAsync(id);
        }

        public async Task CreateStoreAsync(Store store)
        {
            try
            {
                _context.Store.Add(store);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        public async Task UpdateStoreAsync(Store store)
        {
            try
            {
                _context.Entry(store).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        public async Task DeleteStoreAsync(int id)
        {
            try
            {
                var store = await _context.Store.FindAsync(id);
                if (store != null)
                {
                    _context.Store.Remove(store);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }
    }
}
