using Serper.API.Entity;
using Serper.BLL.Entity;
using Microsoft.AspNetCore.Mvc;
using Serper.BLL.Service.SearchRequest;

namespace Serper.Web.Controllers
{
    [ApiController]
    [Route("api/searhrequest")]
    public sealed class SearchRequestController : Controller
    {
        public SearchRequestController(ISearchRequestService searchRequestService)
        {
            _searchRequestService = searchRequestService 
                ?? throw new ArgumentNullException(nameof(searchRequestService));
        }

        private readonly ISearchRequestService _searchRequestService;

        [HttpPost]
        public IActionResult InsertSearchRequest(RootObject rootObject)
        {
            var searchDTO = new SearchRequestDTO
            {
                DescriptionLink = rootObject.knowledgeGraph.descriptionLink,
                Query = rootObject.searchParameters.q
            };

            _searchRequestService.Insert(searchDTO);

            return StatusCode(201);
        }

        #region Get

        [HttpGet]
        public IActionResult GetSearchRequest(int id)
        {
            var searchRequestDTO = _searchRequestService.Get(id);

            return Ok(searchRequestDTO);
        }

        [HttpGet]
        public IActionResult GetSearchesRequests()
        {
            var searchesRequests = _searchRequestService.GetAll();

            return Ok(searchesRequests);
        }

        #endregion
    }
}