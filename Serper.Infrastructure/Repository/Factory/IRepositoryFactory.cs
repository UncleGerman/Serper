using Serper.DAL.Repository;

namespace Serper.Infrastructure.Repository.Factory
{
    internal interface IRepositoryFactory
    {
        public ISearchRequestRepository GetSearchRequestRepository();
    }
}