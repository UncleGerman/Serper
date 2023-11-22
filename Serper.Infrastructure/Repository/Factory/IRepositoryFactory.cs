using Serper.DAL.Repository;

namespace Serper.Infrastructure.Repository.Factory
{
    internal interface IRepositoryFactory
    {
        public ISearchResultRepository GetSearchResultRepository();
    }
}