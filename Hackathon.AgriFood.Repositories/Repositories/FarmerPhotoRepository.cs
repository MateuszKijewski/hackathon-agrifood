using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories
{
    public class FarmerPhotoRepository : IRepository<FarmerPhoto>
    {
        private readonly AgriFoodDbContext _db;

        public FarmerPhotoRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(FarmerPhoto entity)
        {
            await _db.FarmerPhotos.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<FarmerPhoto> entities)
        {
            await _db.FarmerPhotos.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(FarmerPhoto entity)
        {
            _db.FarmerPhotos.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<FarmerPhoto> entities)
        {
            _db.FarmerPhotos.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<FarmerPhoto> Get(Guid id)
        {
            var farmerPhoto = await _db.FarmerPhotos
                .Include(x => x.Farmer)
                .SingleOrDefaultAsync(x => x.Id == id);

            return farmerPhoto;
        }

        public async Task<IEnumerable<FarmerPhoto>> GetAll()
        {
            var farmerPhotos = await _db.FarmerPhotos
                .Include(x => x.Farmer)
                .ToListAsync();

            return farmerPhotos;
        }

        public async Task Update(FarmerPhoto entity)
        {
            _db.FarmerPhotos.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<FarmerPhoto> entities)
        {
            _db.FarmerPhotos.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
