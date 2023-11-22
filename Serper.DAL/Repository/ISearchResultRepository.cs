using Serper.DAL.Entity;

namespace Serper.DAL.Repository
{
    public interface ISearchResultRepository
    {
        public Task InsertAsync(SearchResult searchRequest);

        public Task<SearchResult> GetByIdAsnyc(string id);

        public IReadOnlyCollection<SearchResult> GetAll();

    }
}