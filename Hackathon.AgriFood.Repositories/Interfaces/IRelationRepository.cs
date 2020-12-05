using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Repositories.Interfaces
{
    public interface IRelationRepository<TEntity>
        where TEntity : class
    {
        Task Add(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entities);

        Task<TEntity> Get(Guid firstId, Guid secondId);

        Task<IEnumerable<TEntity>> GetByFirstId(Guid firstId);
        Task<IEnumerable<TEntity>> GetBySecondId(Guid secondId);

        Task<IEnumerable<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task UpdateRange(IEnumerable<TEntity> entities);

        Task Delete(TEntity entity);

        Task DeleteRange(IEnumerable<TEntity> entities);
    }
}