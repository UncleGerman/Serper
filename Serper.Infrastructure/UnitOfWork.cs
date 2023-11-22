using Serper.DAL;
using Serper.DAL.EntityFramework;
using Serper.DAL.Repository;
using Serper.Infrastructure.Repository.Factory;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Serper.Web")]
[assembly: InternalsVisibleTo("Serper.AuthorizationServer")]
[assembly: InternalsVisibleTo("Serper.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Serper.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            ApplicationContext applicationContext,
            IRepositoryFactory repositoryFactory)
        {
            _applicationContext = applicationContext 
                ?? throw new ArgumentNullException(nameof(applicationContext));

            _repositoryFactory = repositoryFactory
                 ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }

        private readonly ApplicationContext _applicationContext;

        private readonly IRepositoryFactory _repositoryFactory;

        public void Dispose()
        {
            
        }

        public ISearchResultRepository GetSearchRequestRepository()
        {
            return _repositoryFactory.GetSearchResultRepository();
        }

        public void Save()
        {
            _applicationContext.SaveChanges();
        }

        public async void SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
