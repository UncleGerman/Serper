using Serper.DAL;
using Serper.DAL.Repository;
using Serper.Infrastructure.Repository.Factory;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Serper.Web")]
namespace Serper.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory 
                ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }

        private readonly IRepositoryFactory _repositoryFactory;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ISearchRepository GetSearchRepository()
        {
            return _repositoryFactory.GetSearchRepository();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SaveAsynk()
        {
            throw new NotImplementedException();
        }
    }
}
