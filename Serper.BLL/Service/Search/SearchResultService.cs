using AutoMapper;
using System.Runtime.CompilerServices;
using Serper.DAL;
using Serper.DAL.Entity;
using Serper.DAL.Repository;
using Serper.API.Entity;
using Serper.BLL.Entity;

[assembly: InternalsVisibleTo("Serper.Web")]
[assembly: InternalsVisibleTo("Serper.Tests")]
[assembly: InternalsVisibleTo("Serper.Infrastructure")]
namespace Serper.BLL.Service.Search
{
    internal sealed class SearchResultService : ISearchResultService
    {
        public SearchResultService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _searchResultRepository = unitOfWork.GetSearchRequestRepository();

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        private readonly IUnitOfWork _unitOfWork;

        private readonly ISearchResultRepository _searchResultRepository;

        private readonly IMapper _mapper;

        #region Get

        public async Task<SearchResultDTO> GetByIdAsync(string id)
        {
            var searchResult = await _searchResultRepository.GetByIdAsnyc(id);

            var searchRequestDTO = _mapper.Map<SearchResultDTO>(searchResult);

            return searchRequestDTO;
        }

        public IReadOnlyCollection<SearchResultDTO> GetAll()
        {
            var searchRequestCollection = _searchResultRepository.GetAll();

            var searchRequestDTOCollection = _mapper.Map<IReadOnlyCollection<SearchResultDTO>>(searchRequestCollection);

            return searchRequestDTOCollection;
        }

        #endregion

        #region Insert

        public async Task<EntityResult> InsertAsync(RootObject rootObject)
        {
            if (rootObject == null)
            {
                throw new ArgumentNullException(
                    nameof(rootObject),
                    "RootObject can not be null");
            }

            var result = new EntityResult();

            var organic = GetOrganic(rootObject);

            if (organic == null)
            {
                result.ErrorMessage = "Request not found";
            }
            else
            {
                result.Success = true;

                await InsertAsync(organic);

                return result;
            }

            return result;
        }

        private static Organic? GetOrganic(RootObject rootObject)
        {
            if (rootObject.Organic == null)
            {
                throw new ArgumentNullException(
                    nameof(rootObject.Organic),
                    "Organic can not be null!");
            }

            if (rootObject.SearchParameters == null)
            {
                throw new ArgumentNullException(
                    nameof(rootObject.Organic),
                    "SearchParameters can not be null!");
            }

            var organic = rootObject.Organic.FirstOrDefault(
                r => r.title == rootObject.SearchParameters.q);

            return organic;
        }

        private async Task InsertAsync(Organic organic)
        {
            var searchResult = _mapper.Map<Organic, SearchResult>(organic);

            await _searchResultRepository.InsertAsync(searchResult);

            _unitOfWork.Save();
        }

        #endregion

    }
}