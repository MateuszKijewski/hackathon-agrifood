using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories
{
    public class LocalizationRepository : IRepository<Localization>
    {
        private readonly AgriFoodDbContext _db;

        public LocalizationRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(Localization entity)
        {
            await _db.Localizations.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<Localization> entities)
        {
            await _db.Localizations.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Localization entity)
        {
            _db.Localizations.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<Localization> entities)
        {
            _db.Localizations.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<Localization> Get(Guid id)
        {
            var localization = await _db.Localizations
                .Include(l => l.Farmers)
                .Include(l => l.Shops)
                .SingleOrDefaultAsync(x => x.Id == id);

            return localization;
        }

        public async Task<IEnumerable<Localization>> GetAll()
        {
            var localizations = await _db.Localizations
                .Include(l => l.Farmers)
                .Include(l => l.Shops)
                .ToListAsync();

            return localizations;
        }

        public async Task Update(Localization entity)
        {
            _db.Localizations.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<Localization> entities)
        {
            _db.Localizations.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
