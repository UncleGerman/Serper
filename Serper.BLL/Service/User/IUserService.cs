using Microsoft.AspNetCore.Identity;
using Serper.BLL.Entity;
using Serper.BLL.Entity.Identity;

namespace Serper.BLL.Service.User
{
    public interface IUserService
    {
        public Task<IdentityResult> InsertAsync(ApplicationUserDTO applicationUserDTO);

        public Task<IdentityResult> UpdateAsync(ApplicationUserDTO applicationUserDTO);

        public Task<IdentityResult> RemoveAsync(string id);

        #region Get

        public Task<ApplicationUserDTO> GetByEmailAsync(string email);

        public Task<ApplicationUserDTO> GetByIdAsync(string id);

        public IReadOnlyCollection<ApplicationUserDTO> GetAll();

        public Task<IReadOnlyCollection<SearchResultDTO>> GetUserSearchResults(string id);

        #endregion

        #region User Role

        public Task<IdentityResult> AddRoleAsync(ApplicationUserDTO applicationUserDTO, string role);

        public Task<IdentityResult> RemoveRoleAsync(ApplicationUserDTO applicationUserDTO, string role);

        #endregion
    }
}
