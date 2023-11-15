using Serper.BLL.Entity;

namespace Serper.BLL.Service
{
    public interface ISearchService
    {
        public void Insert(SearchDTO searchDTO);

        public void Update(SearchDTO searchDTO);

        public void Remove(SearchDTO searchDTO);

        public SearchDTO Get(int id);

        public IReadOnlyCollection<SearchDTO> GetAll();
    }
}