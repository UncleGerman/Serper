using Serper.API.Entity;
using Serper.BLL.Entity;

namespace Serper.BLL.Service.Search
{
    public interface ISearchResultService
    {
        public Task<EntityResult> InsertAsync(RootObject rootObject);

        public Task<SearchResultDTO> GetByIdAsync(string id);

        public IReadOnlyCollection<SearchResultDTO> GetAll();

    }
}