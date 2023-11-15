using Microsoft.AspNetCore.Mvc;
using Serper.API.Entity;
using Serper.API.Services;
using Serper.BLL.Entity;
using Serper.BLL.Service;

namespace Serper.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ISearchService searchService, ISerperRequestService serperRequestService)
        {
            _searchService = searchService
                ?? throw new ArgumentNullException(nameof(searchService));

            _serperRequestService = serperRequestService
                ?? throw new ArgumentNullException(nameof(serperRequestService));
        }

        private readonly ISearchService _searchService;

        private readonly ISerperRequestService _serperRequestService;

        [HttpPost]
        public IActionResult SendReqest(SearchParameters searchParameters)
        {
            _serperRequestService.Request(searchParameters);

            var result = _serperRequestService.GetRootObject();

            var searchDTO = new SearchDTO()
            {
                Query = searchParameters.q,
                DescriptionLink = result.knowledgeGraph.descriptionLink
            };

            _searchService.Insert(searchDTO);

            return View(result);
        }
    }
}