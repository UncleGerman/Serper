using Microsoft.AspNetCore.Identity;
using Serper.BLL.Entity;

namespace Serper.BLL.Service.Identity.User
{
    public interface IUserService
    {
        public Task<IdentityResult> InsertAsync(ApplicationUserDTO applicationUserDTO);

        public Task<IdentityResult> UpdateAsync(ApplicationUserDTO applicationUserDTO);

        public Task<IdentityResult> RemoveAsync(string id);

        public Task<ApplicationUserDTO> GetAsync(string id);

        public IReadOnlyCollection<ApplicationUserDTO> GetAll();
    }
}
