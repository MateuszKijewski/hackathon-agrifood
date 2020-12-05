using System;
using Microsoft.Extensions.DependencyInjection;
using Hackathon.AgriFood.Repositories.Interfaces;

namespace Hackathon.AgriFood.Repositories.Providers
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            return  _serviceProvider.GetRequiredService<IRepository<TEntity>>();
        }

        public IRelationRepository<TEntity> GetRelationRepository<TEntity>()
            where TEntity : class
        {
            return _serviceProvider.GetRequiredService<IRelationRepository<TEntity>>();
        }
    }
}
