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
    public class CustomerToProductRepository : IRelationRepository<CustomerToProduct>
    {
        private readonly AgriFoodDbContext _db;

        public CustomerToProductRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(CustomerToProduct entity)
        {
            await _db.CustomerToProducts.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<CustomerToProduct> entities)
        {
            await _db.CustomerToProducts.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(CustomerToProduct entity)
        {
            _db.CustomerToProducts.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<CustomerToProduct> entities)
        {
            _db.CustomerToProducts.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<CustomerToProduct> Get(Guid firstId, Guid secondId)
        {
            var customerToProduct = await _db.CustomerToProducts
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Product)
                .SingleOrDefaultAsync(x => x.CustomerId == firstId && x.ProductId == secondId);

            return customerToProduct;
        }

        public async Task<IEnumerable<CustomerToProduct>> GetByFirstId(Guid firstId)
        {
            var customerToProducts = await _db.CustomerToProducts
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Product)
                .Where(x => x.CustomerId == firstId)
                .ToListAsync();

            return customerToProducts;
        }

        public async Task<IEnumerable<CustomerToProduct>> GetBySecondId(Guid secondId)
        {
            var customerToProducts = await _db.CustomerToProducts
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Product)
                .Where(x => x.ProductId == secondId)
                .ToListAsync();

            return customerToProducts;
        }

        public async Task<IEnumerable<CustomerToProduct>> GetAll()
        {
            var customerToFarmers = await _db.CustomerToProducts
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Product)
                .ToListAsync();
            return customerToFarmers;
        }

        public async Task Update(CustomerToProduct entity)
        {
            _db.CustomerToProducts.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<CustomerToProduct> entities)
        {
            _db.CustomerToProducts.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}