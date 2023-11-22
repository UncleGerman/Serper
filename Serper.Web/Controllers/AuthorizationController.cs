using Microsoft.AspNetCore.Mvc;
using Serper.BLL.Entity.Authorization;
using Serper.BLL.Service.Authorization;

namespace Serper.AuthorizationServer.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizationController : Controller
    {
        public AuthorizationController(IAuthorizationsService accountService)
        {
            _authorizationService = accountService
                ?? throw new ArgumentNullException(nameof(accountService));
        }

        private readonly IAuthorizationsService _authorizationService;

        [HttpPost]
        public async Task<IActionResult> SignUp(AuthorizationParameters authorizationParameters)
        {
            if (authorizationParameters == null)
            {
                return StatusCode(400, "AuthorizationParameters can not be null");
            }

            var identityResult = await _authorizationService.SignUp(authorizationParameters);

            if (identityResult.Succeeded)
            {
                return StatusCode(201);
            }

            return StatusCode(400, identityResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AuthorizationParameters authorizationParameters)
        {
            if (authorizationParameters == null)
            {
                return StatusCode(400, "AuthorizationParameters not be null");
            }

            if (string.IsNullOrEmpty(authorizationParameters.Email))
            {
                return StatusCode(400, "Email not be empty");
            }

            var result = await _authorizationService.SignIn(authorizationParameters);

            return StatusCode(400, result);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _authorizationService.SignOutAsync();

            return StatusCode(200);
        }
    }
}
