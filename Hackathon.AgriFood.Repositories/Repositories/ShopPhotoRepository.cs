using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories
{
    public class ShopPhotoRepository : IRepository<ShopPhoto>
    {
        private readonly AgriFoodDbContext _db;

        public ShopPhotoRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(ShopPhoto entity)
        {
            await _db.ShopPhotos.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<ShopPhoto> entities)
        {
            await _db.ShopPhotos.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(ShopPhoto entity)
        {
            _db.ShopPhotos.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<ShopPhoto> entities)
        {
            _db.ShopPhotos.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<ShopPhoto> Get(Guid id)
        {
            var shopPhoto = await _db.ShopPhotos
                .Include(sp => sp.Shop)
                .SingleOrDefaultAsync(x => x.Id == id);

            return shopPhoto;
        }

        public async Task<IEnumerable<ShopPhoto>> GetAll()
        {
            var shopPhotos = await _db.ShopPhotos
                .Include(sp => sp.Shop)
                .ToListAsync();

            return shopPhotos;
        }

        public async Task Update(ShopPhoto entity)
        {
            _db.ShopPhotos.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<ShopPhoto> entities)
        {
            _db.ShopPhotos.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
