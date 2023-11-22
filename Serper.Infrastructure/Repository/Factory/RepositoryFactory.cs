using Serper.DAL.Entity;
using Serper.DAL.Repository;
using Serper.DAL.EntityFramework;

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

        public ISearchResultRepository GetSearchResultRepository()
        {
            return new SearchResultRepository(_applicationContext.Set<SearchResult>());
        }
    }
}