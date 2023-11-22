using Serper.BLL.Entity;

namespace Serper.BLL.Service.SearchRequest
{
    public interface ISearchRequestService
    {
        public void Insert(SearchRequestDTO searchRequestDTO);

        public SearchRequestDTO Get(int id);

        public IReadOnlyCollection<SearchRequestDTO> GetAll();
    }
}