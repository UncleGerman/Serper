using AutoMapper;
using System.Runtime.CompilerServices;
using Serper.BLL.Entity;
using Serper.DAL;
using Serper.DAL.Entity;
using Serper.DAL.Repository;

[assembly: InternalsVisibleTo("Serper.Web")]
[assembly: InternalsVisibleTo("Serper.Infrastructure")]
namespace Serper.BLL.Service
{
    internal sealed class SearchService : ISearchService
    {
        public SearchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (unitOfWork is null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            _searchRepository = unitOfWork.GetSearchRepository();

            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        private readonly ISearchRepository _searchRepository;

        private readonly IMapper _mapper;

        public void Remove(SearchDTO searchDTO)
        {
            var search = _mapper.Map<Search>(searchDTO);

            _searchRepository.Remove(search);
        }

        public void Insert(SearchDTO searchDTO)
        {
            var search = _mapper.Map<Search>(searchDTO);

            _searchRepository.Insert(search);
        }

        public void Update(SearchDTO searchDTO)
        {
            var search = _mapper.Map<Search>(searchDTO);

            _searchRepository.Update(search);
        }

        #region Get

        public SearchDTO Get(int id)
        {
            var search = _searchRepository.Get(id);

            var searchDTO = _mapper.Map<SearchDTO>(search);

            return searchDTO;
        }

        public IReadOnlyCollection<SearchDTO> GetAll()
        {
            var searchCollection = _searchRepository.GetAll();

            var searchDTOCollection = _mapper.Map<IReadOnlyCollection<SearchDTO>>(searchCollection);

            return searchDTOCollection;
        }

        #endregion
    }
}