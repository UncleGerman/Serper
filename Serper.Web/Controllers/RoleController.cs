using Microsoft.AspNetCore.Mvc;
using Serper.BLL.Service.Role;
using Serper.BLL.Entity.Identity;

namespace Serper.Web.Controllers
{
    public class RoleController : Controller
    {
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService 
                ?? throw new ArgumentNullException(nameof(roleService));
        }

        private readonly IRoleService _roleService;

        [HttpPost]
        public async Task<IActionResult> InsertAsync(ApplicationRoleDTO applicationRoleDTO)
        {
            if (applicationRoleDTO == null)
            {
                return StatusCode(400, "");
            }

            var result = await _roleService.InsertAsync(applicationRoleDTO);

            if (result.Succeeded)
            {
                var claimResult = await _roleService.AddCalimAsync(applicationRoleDTO);

                if (claimResult.Succeeded)
                {
                    return StatusCode(204, applicationRoleDTO);
                }

                return StatusCode(400, claimResult.Errors);
            }

            return StatusCode(400, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ApplicationRoleDTO applicationRoleDTO)
        {
            if (applicationRoleDTO is null)
            {
                return StatusCode(400, "");
            }

            var result = await _roleService.UpdateAsync(applicationRoleDTO);

            if (result.Succeeded)
            {
                return StatusCode(200, applicationRoleDTO);
            }

            return StatusCode(400, result.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return StatusCode(400, "");
            }

            var result = await _roleService.RemoveAsync(id);

            if (result.Succeeded)
            {
                return StatusCode(200);
            }

            return StatusCode(400, result.Errors);
        }
    }
}