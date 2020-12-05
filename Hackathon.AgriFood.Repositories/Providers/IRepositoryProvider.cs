using Hackathon.AgriFood.Repositories.Interfaces;

namespace Hackathon.AgriFood.Repositories.Providers
{
    public interface IRepositoryProvider
    {
        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;

        public IRelationRepository<TEntity> GetRelationRepository<TEntity>()
            where TEntity : class;
    }
}
