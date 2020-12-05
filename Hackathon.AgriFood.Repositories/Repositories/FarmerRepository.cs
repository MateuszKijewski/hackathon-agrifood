using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories
{
    public class FarmerRepository : IRepository<Farmer>
    {
        private readonly AgriFoodDbContext _db;

        public FarmerRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(Farmer entity)
        {
            await _db.Farmers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<Farmer> entities)
        {
            await _db.Farmers.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Farmer entity)
        {
            _db.Farmers.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<Farmer> entities)
        {
            _db.Farmers.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<Farmer> Get(Guid id)
        {
            var farmer = await _db.Farmers
                .Include(f => f.Localization)
                .Include(f => f.Products)
                .Include(f => f.Photos)
                .Include(f => f.Shops)
                .Include(f => f.FavoringCustomers)
                .ThenInclude(fc => fc.Customer)
                .SingleOrDefaultAsync(x => x.Id == id);

            return farmer;
        }

        public async Task<IEnumerable<Farmer>> GetAll()
        {
            var farmers = await _db.Farmers
                .Include(f => f.Localization)
                .Include(f => f.Products)
                .Include(f => f.Photos)
                .Include(f => f.Shops)
                .Include(f => f.FavoringCustomers)
                .ThenInclude(fc => fc.Customer).ToListAsync();

            return farmers;
        }

        public async Task Update(Farmer entity)
        {
            _db.Farmers.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<Farmer> entities)
        {
            _db.Farmers.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}