using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models.Relations;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories.Relations
{
    public class ShopToFarmerRepository : IRelationRepository<ShopToFarmer>
    {
        private readonly AgriFoodDbContext _db;

        public ShopToFarmerRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(ShopToFarmer entity)
        {
            await _db.ShopToFarmers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<ShopToFarmer> entities)
        {
            await _db.ShopToFarmers.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(ShopToFarmer entity)
        {
            _db.ShopToFarmers.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<ShopToFarmer> entities)
        {
            _db.ShopToFarmers.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<ShopToFarmer> Get(Guid firstId, Guid secondId)
        {
            var shopToFarmer = await _db.ShopToFarmers
                .Include(ctf => ctf.Shop)
                .Include(ctf => ctf.Farmer)
                .SingleOrDefaultAsync(x => x.ShopId == firstId && x.FarmerId == secondId);

            return shopToFarmer;
        }

        public async Task<IEnumerable<ShopToFarmer>> GetByFirstId(Guid firstId)
        {
            var shopToFarmers = await _db.ShopToFarmers
                .Include(ctf => ctf.Shop)
                .Include(ctf => ctf.Farmer)
                .Where(x => x.ShopId == firstId)
                .ToListAsync();

            return shopToFarmers;
        }

        public async Task<IEnumerable<ShopToFarmer>> GetBySecondId(Guid secondId)
        {
            var shopToFarmers = await _db.ShopToFarmers
                .Include(ctf => ctf.Shop)
                .Include(ctf => ctf.Farmer)
                .Where(x => x.FarmerId == secondId)
                .ToListAsync();

            return shopToFarmers;
        }

        public async Task<IEnumerable<ShopToFarmer>> GetAll()
        {
            var shopToFarmers = await _db.ShopToFarmers
                .Include(ctf => ctf.Shop)
                .Include(ctf => ctf.Farmer)
                .ToListAsync();
            return shopToFarmers;
        }

        public async Task Update(ShopToFarmer entity)
        {
            _db.ShopToFarmers.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<ShopToFarmer> entities)
        {
            _db.ShopToFarmers.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
