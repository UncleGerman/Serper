using Microsoft.AspNetCore.Mvc;
using Serper.BLL.Entity;
using Serper.BLL.Service.Identity.User;

namespace Serper.Web.Controllers
{
    [ApiController]
    [Route("api/user")]
    public sealed class UserController : Controller
    {
        public UserController(IUserService userService)
        {
            _userService = userService 
                ?? throw new ArgumentNullException(nameof(userService));
        }

        private readonly IUserService _userService;

        [HttpPost]
        public IActionResult InsertUser(ApplicationUserDTO applicationUserDTO)
        {
            return View(applicationUserDTO);
        }

        [HttpPut]
        public IActionResult UpdateUser(ApplicationUserDTO applicationUserDTO)
        {
            return View(applicationUserDTO);
        }

        [HttpDelete]
        public IActionResult DeleteUser(ApplicationUserDTO applicationUserDTO)
        {
            return View(applicationUserDTO);
        }

        [HttpGet("id")]
        public IActionResult GetUser(string id)
        {
            return View(new ApplicationUserDTO { });
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return View();
        }
    }
}