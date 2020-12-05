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
    public class CustomerToFarmerRepository : IRelationRepository<CustomerToFarmer>
    {
        private readonly AgriFoodDbContext _db;

        public CustomerToFarmerRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(CustomerToFarmer entity)
        {
            await _db.CustomerToFarmers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<CustomerToFarmer> entities)
        {
            await _db.CustomerToFarmers.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(CustomerToFarmer entity)
        {
            _db.CustomerToFarmers.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<CustomerToFarmer> entities)
        {
            _db.CustomerToFarmers.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<CustomerToFarmer> Get(Guid firstId, Guid secondId)
        {
            var customerToFarmer = await _db.CustomerToFarmers
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Farmer)           
                .SingleOrDefaultAsync(x => x.CustomerId == firstId && x.FarmerId == secondId);

            return customerToFarmer;
        }

        public async Task<IEnumerable<CustomerToFarmer>> GetByFirstId(Guid firstId)
        {
            var customerToFarmers = await _db.CustomerToFarmers
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Farmer)
                .Where(x => x.CustomerId == firstId)
                .ToListAsync();

            return customerToFarmers;
        }

        public async Task<IEnumerable<CustomerToFarmer>> GetBySecondId(Guid secondId)
        {
            var customerToFarmers = await _db.CustomerToFarmers
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Farmer)
                .Where(x => x.FarmerId == secondId)
                .ToListAsync();

            return customerToFarmers;
        }

        public async Task<IEnumerable<CustomerToFarmer>> GetAll()
        {
            var customerToFarmers = await _db.CustomerToFarmers
                .Include(ctf => ctf.Customer)
                .Include(ctf => ctf.Farmer)
                .ToListAsync();
            return customerToFarmers;
        }

        public async Task Update(CustomerToFarmer entity)
        {
            _db.CustomerToFarmers.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<CustomerToFarmer> entities)
        {
            _db.CustomerToFarmers.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
