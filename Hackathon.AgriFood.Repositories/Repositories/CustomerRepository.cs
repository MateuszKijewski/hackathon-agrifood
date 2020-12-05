using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly AgriFoodDbContext _db;

        public CustomerRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(Customer entity)
        {
            await _db.Customers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<Customer> entities)
        {
            await _db.Customers.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Customer entity)
        {
            _db.Customers.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<Customer> entities)
        {
            _db.Customers.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<Customer> Get(Guid id)
        {
            var customer = await _db.Customers
                .Include(c => c.FavoriteFarmers)
                .ThenInclude(ff => ff.Farmer)
                .Include(c => c.FavoriteProducts)
                .ThenInclude(fp => fp.Product)
                .Include(c => c.FavoriteShops)
                .ThenInclude(fs => fs.Shop)
                .SingleOrDefaultAsync(x => x.Id == id);

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _db.Customers
                .Include(c => c.FavoriteFarmers)
                .ThenInclude(ff => ff.Farmer)
                .Include(c => c.FavoriteProducts)
                .ThenInclude(fp => fp.Product)
                .Include(c => c.FavoriteShops)
                .ThenInclude(fs => fs.Shop)
                .ToListAsync();
            return customers;
        }

        public async Task Update(Customer entity)
        {
            _db.Customers.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<Customer> entities)
        {
            _db.Customers.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
