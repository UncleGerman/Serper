using Serper.DAL.Entity;
using Serper.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace Serper.Infrastructure.Repository
{
    internal sealed class SearchRequestRepository : ISearchRequestRepository
    {
        public SearchRequestRepository(DbSet<SearchRequest> searches)
        {
            _searches = searches 
                ?? throw new ArgumentNullException(nameof(searches));
        }

        private readonly DbSet<SearchRequest> _searches;

        public void Insert(SearchRequest searchRequest)
        {
            _searches.Remove(searchRequest);
        }

        #region Get

        public SearchRequest Get(int id)
        {
            var search = _searches.FirstOrDefault(s => s.Id == id);

            return search ?? throw new ArgumentNullException(nameof(search));
        }

        public IReadOnlyCollection<SearchRequest> GetAll()
        {
            return _searches.ToList();
        }

        #endregion
    }
}