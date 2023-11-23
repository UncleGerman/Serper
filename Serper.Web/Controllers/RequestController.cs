using Serper.API.Services;
using Microsoft.AspNetCore.Mvc;
using Serper.API.Entity;
using System.Text.Json;

namespace Serper.Web.Controllers
{
    [ApiController]
    [Route("api/request")]
    public sealed class RequestController : Controller
    {
        public RequestController(ISerperRequestService serperRequestService)
        {
            _serperRequestService = serperRequestService 
                ?? throw new ArgumentNullException(nameof(serperRequestService));
        }

        private readonly ISerperRequestService _serperRequestService;

        [HttpPost]
        public IActionResult SendReqest(SearchParameters searchParameters)
        {
            try
            {
                var response = _serperRequestService.RequestToApi(searchParameters);

                var rootObject = JsonSerializer.Deserialize<RootObject>(response.Content);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}