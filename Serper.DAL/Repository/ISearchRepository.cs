using Serper.DAL.Entity;

namespace Serper.DAL.Repository
{
    internal interface ISearchRepository
    {
        public void Insert(Search search);

        public void Update(Search search);

        public void Remove(Search search);

        public Search Get(int id);

        public IReadOnlyCollection<Search> GetAll();
    }
}