using Microsoft.AspNetCore.Identity;
using Serper.BLL.Entity.Identity;

namespace Serper.BLL.Service.Role
{
    public interface IRoleService
    {
        public Task<IdentityResult> InsertAsync(ApplicationRoleDTO applicationRoleDTO);

        public Task<IdentityResult> UpdateAsync(ApplicationRoleDTO applicationRoleDTO);

        public Task<IdentityResult> RemoveAsync(string id);

        public Task<IdentityResult> AddCalimAsync(ApplicationRoleDTO applicationRoleDTO);
    }
}