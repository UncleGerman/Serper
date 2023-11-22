using Microsoft.AspNetCore.Mvc;
using Serper.API.Entity;
using Serper.BLL.Service.Search;

namespace Serper.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class SearchRequestController : Controller
    {
        public SearchRequestController(ISearchResultService searchRequestService)
        {
            _searchResultService = searchRequestService 
                ?? throw new ArgumentNullException(nameof(searchRequestService));
        }

        private readonly ISearchResultService _searchResultService;

        [HttpPost]
        public async Task<IActionResult> InsertAsync(RootObject rootObject)
        {
            if (rootObject == null)
            {
                return StatusCode(400, "RootObject not be null");
            }

            var result = await _searchResultService.InsertAsync(rootObject);

            if (result.Success)
            {
                return StatusCode(201, "Created");
            }

            return StatusCode(200, result.ErrorMessage);
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(400, "Id not be empty");
            }

            var searchRequestDTO = await _searchResultService.GetByIdAsync(id);

            return StatusCode(200, searchRequestDTO);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var searchesRequests = _searchResultService.GetAll();

            return StatusCode(200, searchesRequests);
        }

        #endregion
    }
}