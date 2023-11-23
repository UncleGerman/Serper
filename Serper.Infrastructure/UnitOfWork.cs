using Serper.DAL;
using Serper.DAL.EntityFramework;
using Serper.DAL.Repository;
using Serper.Infrastructure.Repository.Factory;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Serper.Web")]
namespace Serper.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext 
                ?? throw new ArgumentNullException(nameof(applicationContext));

            _repositoryFactory = new RepositoryFactory(applicationContext);
        }

        private readonly ApplicationContext _applicationContext;

        private readonly IRepositoryFactory _repositoryFactory;

        public void Dispose()
        {
            
        }

        public ISearchRequestRepository GetSearchRequestRepository()
        {
            return _repositoryFactory.GetSearchRequestRepository();
        }

        public void Save()
        {
            _applicationContext.SaveChanges();
        }

        public void SaveAsynk()
        {
            _applicationContext.SaveChangesAsync();
        }
    }
}
