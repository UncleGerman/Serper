using Serper.DAL.Entity;

namespace Serper.DAL.Repository
{
    public interface ISearchRequestRepository
    {
        public void Insert(SearchRequest searchRequest);

        public SearchRequest Get(int id);

        public IReadOnlyCollection<SearchRequest> GetAll();
    }
}