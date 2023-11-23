using Serper.DAL;
using Serper.DAL.Entity;
using Serper.DAL.Repository;
using Serper.BLL.Entity;
using AutoMapper;
using System.Runtime.CompilerServices;
using Serper.BLL.Service.Validate;

[assembly: InternalsVisibleTo("Serper.Web")]
[assembly: InternalsVisibleTo("Serper.Infrastructure")]
namespace Serper.BLL.Service.SearchRequest
{
    internal sealed class SearchRequestService : ISearchRequestService
    {
        public SearchRequestService(
            IValueValidateService valueValidateService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _valueValidateService = valueValidateService
                ?? throw new ArgumentNullException(nameof(valueValidateService));

            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));

            _searchRequestRepository = unitOfWork.GetSearchRequestRepository();

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        private readonly IValueValidateService _valueValidateService;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ISearchRequestRepository _searchRequestRepository;

        private readonly IMapper _mapper;

        public void Insert(SearchRequestDTO searchRequestDTO)
        {
            _valueValidateService.CheckValue(searchRequestDTO);

            var searchRequest = _mapper.Map<SearchRequest>(searchRequestDTO);

            _searchRequestRepository.Insert(searchRequest);

            _unitOfWork.Save();
        }

        #region Get

        public SearchRequestDTO Get(int id)
        {
            _valueValidateService.CheckValue(id);

            var searchRequest = _searchRequestRepository.Get(id);

            _valueValidateService.CheckValue(searchRequest);

            var searchRequestDTO = _mapper.Map<SearchRequestDTO>(searchRequest);

            return searchRequestDTO;
        }

        public IReadOnlyCollection<SearchRequestDTO> GetAll()
        {
            var searchRequestCollection = _searchRequestRepository.GetAll();

            var searchRequestDTOCollection = _mapper.Map<IReadOnlyCollection<SearchRequestDTO>>(searchRequestCollection);

            return searchRequestDTOCollection;
        }

        #endregion
    }
}