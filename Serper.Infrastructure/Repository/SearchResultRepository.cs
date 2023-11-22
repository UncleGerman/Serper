using Microsoft.EntityFrameworkCore;
using Serper.DAL.Entity;
using Serper.DAL.Repository;

namespace Serper.Infrastructure.Repository
{
    internal sealed class SearchResultRepository : ISearchResultRepository
    {
        public SearchResultRepository(DbSet<SearchResult> searchResults)
        {
            _searchResults = searchResults 
                ?? throw new ArgumentNullException(nameof(searchResults));
        }

        private readonly DbSet<SearchResult> _searchResults;

        public async Task InsertAsync(SearchResult searchResult)
        {
            await _searchResults.AddAsync(searchResult);
        }

        #region Get

        public async Task<SearchResult> GetByIdAsnyc(string id)
        {
            var searchResult = await _searchResults.FirstOrDefaultAsync(s => s.Id == id);

            return searchResult;
        }

        public IReadOnlyCollection<SearchResult> GetAll()
        {
            return _searchResults.ToList();
        }

        #endregion
    }
}