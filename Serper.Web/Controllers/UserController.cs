using Microsoft.AspNetCore.Mvc;
using Serper.BLL.Entity.Identity;
using Serper.BLL.Service.User;

namespace Serper.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public sealed class UserController : Controller
    {
        public UserController(IUserService userService)
        {
            _userService = userService 
                ?? throw new ArgumentNullException(nameof(userService));
        }

        private readonly IUserService _userService;

        [HttpPost]
        public async Task<IActionResult> InsertAsync(ApplicationUserDTO applicationUserDTO)
        {
            if (applicationUserDTO == null)
            {
                return StatusCode(400, "User not be null");
            }

            var result = await _userService.InsertAsync(applicationUserDTO);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(applicationUserDTO.RoleName))
                {
                    return StatusCode(400, "User Role can not be empty");
                }

                var roleResult = await _userService.AddRoleAsync(applicationUserDTO, applicationUserDTO.RoleName);

                if (roleResult.Succeeded)
                {
                    return StatusCode(201, applicationUserDTO);
                }

                return StatusCode(400, roleResult.Errors);
            }

            return StatusCode(400, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ApplicationUserDTO applicationUserDTO)
        {
            if (applicationUserDTO == null)
            {
                return StatusCode(400, "User not be null");
            }

            var result = await _userService.UpdateAsync(applicationUserDTO);

            if (result.Succeeded)
            {
                return StatusCode(200, applicationUserDTO);
            }

            return StatusCode(204, result.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(400, "Id not be empty");
            }

            var result = await _userService.RemoveAsync(id);

            if (result.Succeeded)
            {
                return StatusCode(202, id);
            }

            return StatusCode(400, result.Errors);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(400, "Id not be empty");
            }

            var user = await _userService.GetByIdAsync(id);

            return StatusCode(200, user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var applicationUsersDTO = _userService.GetAll();

            return StatusCode(200, applicationUsersDTO);
        }
    }
}