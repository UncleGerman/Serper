using Serper.DAL.Entity;
using Serper.DAL.EntityFramework;
using Serper.DAL.Repository;

namespace Serper.Infrastructure.Repository.Factory
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        public RepositoryFactory(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext 
                ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        private readonly ApplicationContext _applicationContext;

        public ISearchRequestRepository GetSearchRequestRepository()
        {
            return new SearchRequestRepository(_applicationContext.Set<SearchRequest>());
        }
    }
}