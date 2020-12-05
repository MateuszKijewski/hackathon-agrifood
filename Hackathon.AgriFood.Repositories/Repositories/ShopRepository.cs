using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories
{
    public class ShopRepository : IRepository<Shop>
    {
        private readonly AgriFoodDbContext _db;

        public ShopRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(Shop entity)
        {
            await _db.Shops.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<Shop> entities)
        {
            await _db.Shops.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Shop entity)
        {
            _db.Shops.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<Shop> entities)
        {
            _db.Shops.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<Shop> Get(Guid id)
        {
            var shop = await _db.Shops
                .Include(s => s.Localization)
                .Include(s => s.Products)
                .Include(s => s.Photos)
                .Include(s => s.Farmers)
                .ThenInclude(f => f.Farmer)
                .Include(s => s.FavoringCustomers)
                .ThenInclude(fc => fc.Customer)
                .SingleOrDefaultAsync(x => x.Id == id);

            return shop;
        }

        public async Task<IEnumerable<Shop>> GetAll()
        {
            var shops = await _db.Shops
                .Include(s => s.Localization)
                .Include(s => s.Products)
                .Include(s => s.Photos)
                .Include(s => s.Farmers)
                .ThenInclude(f => f.Farmer)
                .Include(s => s.FavoringCustomers)
                .ThenInclude(fc => fc.Customer)
                .ToListAsync();

            return shops;
        }

        public async Task Update(Shop entity)
        {
            _db.Shops.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<Shop> entities)
        {
            _db.Shops.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
