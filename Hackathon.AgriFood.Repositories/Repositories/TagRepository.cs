using Hackathon.AgriFood.DataAccess;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly AgriFoodDbContext _db;

        public TagRepository(AgriFoodDbContext db)
        {
            _db = db;
        }

        public async Task Add(Tag entity)
        {
            await _db.Tags.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<Tag> entities)
        {
            await _db.Tags.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Tag entity)
        {
            _db.Tags.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<Tag> entities)
        {
            _db.Tags.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public async Task<Tag> Get(Guid id)
        {
            var tag = await _db.Tags
                .Include(t => t.TaggedProducts)
                .ThenInclude(tp => tp.Product)
                .SingleOrDefaultAsync(x => x.Id == id);

            return tag;
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            var tags = await _db.Tags
                .Include(t => t.TaggedProducts)
                .ThenInclude(tp => tp.Product)
                .ToListAsync();

            return tags;
        }

        public async Task Update(Tag entity)
        {
            _db.Tags.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<Tag> entities)
        {
            _db.Tags.UpdateRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
