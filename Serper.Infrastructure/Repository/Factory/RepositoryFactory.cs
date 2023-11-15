using Serper.DAL.Repository;

namespace Serper.Infrastructure.Repository.Factory
{
    internal class RepositoryFactory : IRepositoryFactory
    {
        public RepositoryFactory()
        {
        }

        public ISearchRepository GetSearchRepository()
        {
            return new SearchRepository();
        }
    }
}