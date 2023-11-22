using Serper.DAL.Repository;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Serper.Infrastructure")]
[assembly: InternalsVisibleTo("Serper.BLL")]
[assembly: InternalsVisibleTo("Serper.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Serper.DAL
{
    internal interface IUnitOfWork : IDisposable
    {
        public void Save();

        public void SaveAsync();

        public ISearchResultRepository GetSearchRequestRepository();
    }
}