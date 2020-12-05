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
    public class CustomerToShopRepository : IRelationRepository<CustomerToShop>
    {
        private readonly AgriFoodDbContext _db;

        public CustomerToShopRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(CustomerToShop entity)
        {
            await _db.CustomerToShops.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<CustomerToShop> entities)
        {
            await _db.CustomerToShops.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(CustomerToShop entity)
        {
            _db.CustomerToShops.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<CustomerToShop> entities)
        {
            _db.CustomerToShops.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<CustomerToShop> Get(Guid firstId, Guid secondId)
        {
            var customerToShop = await _db.CustomerToShops
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Shop)
                .SingleOrDefaultAsync(x => x.CustomerId == firstId && x.ShopId == secondId);

            return customerToShop;
        }

        public async Task<IEnumerable<CustomerToShop>> GetByFirstId(Guid firstId)
        {
            var customerToShops = await _db.CustomerToShops
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Shop)
                .Where(x => x.CustomerId == firstId)
                .ToListAsync();

            return customerToShops;
        }

        public async Task<IEnumerable<CustomerToShop>> GetBySecondId(Guid secondId)
        {
            var customerToShops = await _db.CustomerToShops
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Shop)
                .Where(x => x.ShopId == secondId)
                .ToListAsync();

            return customerToShops;
        }

        public async Task<IEnumerable<CustomerToShop>> GetAll()
        {
            var customerToShops = await _db.CustomerToShops
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Shop)
                .ToListAsync();
            return customerToShops;
        }

        public async Task Update(CustomerToShop entity)
        {
            _db.CustomerToShops.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<CustomerToShop> entities)
        {
            _db.CustomerToShops.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}