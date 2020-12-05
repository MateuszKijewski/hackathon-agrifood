using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task Add(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entities);

        Task<TEntity> Get(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task UpdateRange(IEnumerable<TEntity> entities);

        Task Delete(TEntity entity);

        Task DeleteRange(IEnumerable<TEntity> entities);
    }
}