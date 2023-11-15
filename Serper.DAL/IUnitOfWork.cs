using Serper.DAL.Repository;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Serper.Infrastructure")]
[assembly: InternalsVisibleTo("Serper.BLL")]
namespace Serper.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        public void Save();

        public void SaveAsynk();

        public ISearchRepository GetSearchRepository();
    }
}