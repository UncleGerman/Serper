using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Serper.BLL.Entity;
using Serper.DAL.Entity.Identity;

namespace Serper.BLL.Service.Identity.User
{
    internal sealed class UserService : BaseIdentityService, IUserService
    {
        public UserService(
            UserManager<ApplicationUser> userManager,
            IMapper mapper) : base(userManager, mapper)
        {
        }

        public async Task<IdentityResult> RemoveAsync(string id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id);

            return await _userManager.DeleteAsync(applicationUser);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDTO);

            return await _userManager.UpdateAsync(applicationUser);
        }

        #region Get

        public async Task<ApplicationUserDTO> GetAsync(string id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id);

            var applicationUserDTO = _mapper.Map<ApplicationUserDTO>(applicationUser);

            return applicationUserDTO;
        }

        public IReadOnlyCollection<ApplicationUserDTO> GetAll()
        {
            var applicationUsers = _userManager.Users;

            var applicationUsersDTO = _mapper.Map<IReadOnlyCollection<ApplicationUserDTO>>(applicationUsers);

            return applicationUsersDTO;
        }

        #endregion
    }
}