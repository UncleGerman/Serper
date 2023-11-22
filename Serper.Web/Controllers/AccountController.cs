using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serper.BLL.Entity;
using Serper.BLL.Service.Identity.Account;

namespace Serper.Web.Controllers
{
    [ApiController]
    [Route("api/account")]
    public sealed class AccountController : Controller
    {
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService 
                ?? throw new ArgumentNullException(nameof(accountService));
        }

        private readonly IAccountService _accountService;

        [HttpPost]
        public IActionResult Register(ApplicationUserDTO applicationUserDTO)
        {
            _accountService.InsertAsync(applicationUserDTO);
            _accountService.SignInAsync(applicationUserDTO);

            return Ok();
        }

        [HttpPost]
        public IActionResult Login(ApplicationUserDTO applicationUserDTO)
        {
            _accountService.PasswordSignInAsync(applicationUserDTO);

            return Ok();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _accountService.SignOutAsync();

            return Ok();
        }
    }
}