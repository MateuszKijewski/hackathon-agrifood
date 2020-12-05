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
    public class TagToProductRepository : IRelationRepository<TagToProduct>
    {
        private readonly AgriFoodDbContext _db;

        public TagToProductRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(TagToProduct entity)
        {
            await _db.TagToProducts.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<TagToProduct> entities)
        {
            await _db.TagToProducts.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(TagToProduct entity)
        {
            _db.TagToProducts.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<TagToProduct> entities)
        {
            _db.TagToProducts.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<TagToProduct> Get(Guid firstId, Guid secondId)
        {
            var tagToProduct = await _db.TagToProducts
                .Include(ctf => ctf.Tag)
                .Include(ctf => ctf.Product)
                .SingleOrDefaultAsync(x => x.TagId == firstId && x.ProductId == secondId);

            return tagToProduct;
        }

        public async Task<IEnumerable<TagToProduct>> GetByFirstId(Guid firstId)
        {
            var tagToProducts = await _db.TagToProducts
                .Include(ctf => ctf.Tag)
                .Include(ctf => ctf.Product)
                .Where(x => x.TagId == firstId)
                .ToListAsync();

            return tagToProducts;
        }

        public async Task<IEnumerable<TagToProduct>> GetBySecondId(Guid secondId)
        {
            var tagToProducts = await _db.TagToProducts
                .Include(ctf => ctf.Tag)
                .Include(ctf => ctf.Product)
                .Where(x => x.ProductId == secondId)
                .ToListAsync();

            return tagToProducts;
        }

        public async Task<IEnumerable<TagToProduct>> GetAll()
        {
            var tagToProducts = await _db.TagToProducts
                .Include(ctf => ctf.Tag)
                .Include(ctf => ctf.Product)
                .ToListAsync();
            return tagToProducts;
        }

        public async Task Update(TagToProduct entity)
        {
            _db.TagToProducts.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<TagToProduct> entities)
        {
            _db.TagToProducts.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
