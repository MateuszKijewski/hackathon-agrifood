using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AgriFoodDbContext _db;

        public ProductRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(Product entity)
        {
            await _db.Products.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<Product> entities)
        {
            await _db.Products.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        {
            _db.Products.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<Product> entities)
        {
            _db.Products.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> Get(Guid id)
        {
            var product = await _db.Products
                .Include(p => p.Farmer)
                .Include(p => p.Shop)
                .Include(p => p.Photos)
                .Include(p => p.Tags)
                .Include(p => p.FavoringCustomers)
                .ThenInclude(fc => fc.Customer)
                .SingleOrDefaultAsync(x => x.Id == id);

            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _db.Products
                .Include(p => p.Farmer)
                .Include(p => p.Shop)
                .Include(p => p.Photos)
                .Include(p => p.Tags)
                .Include(p => p.FavoringCustomers)
                .ThenInclude(fc => fc.Customer)
                .ToListAsync();

            return products;
        }

        public async Task Update(Product entity)
        {
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<Product> entities)
        {
            _db.Products.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
