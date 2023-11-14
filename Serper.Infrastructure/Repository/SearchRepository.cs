using Serper.DAL.Entity;
using Serper.DAL.Repository;

namespace Serper.Infrastructure.Repository
{
    internal sealed class SearchRepository : ISearchRepository
    {
        public SearchRepository()
        {

        }

        public Search Get(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Search> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Search search)
        {
            throw new NotImplementedException();
        }

        public void Remove(Search search)
        {
            throw new NotImplementedException();
        }

        public void Update(Search search)
        {
            throw new NotImplementedException();
        }
    }
}