using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories
{
    public class ProductPhotoRepository : IRepository<ProductPhoto>
    {
        private readonly AgriFoodDbContext _db;

        public ProductPhotoRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(ProductPhoto entity)
        {
            await _db.ProductPhotos.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<ProductPhoto> entities)
        {
            await _db.ProductPhotos.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(ProductPhoto entity)
        {
            _db.ProductPhotos.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<ProductPhoto> entities)
        {
            _db.ProductPhotos.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<ProductPhoto> Get(Guid id)
        {
            var productPhoto = await _db.ProductPhotos
                .Include(pp => pp.Product)
                .SingleOrDefaultAsync(x => x.Id == id);

            return productPhoto;
        }

        public async Task<IEnumerable<ProductPhoto>> GetAll()
        {
            var productPhotos = await _db.ProductPhotos
                .Include(pp => pp.Product)
                .ToListAsync();

            return productPhotos;
        }

        public async Task Update(ProductPhoto entity)
        {
            _db.ProductPhotos.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<ProductPhoto> entities)
        {
            _db.ProductPhotos.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
