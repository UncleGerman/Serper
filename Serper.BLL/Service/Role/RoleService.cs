using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Serper.BLL.Entity.Identity;

namespace Serper.BLL.Service.Role
{
    internal sealed class RoleService : IRoleService
    {
        public RoleService(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager 
                ?? throw new ArgumentNullException(nameof(roleManager));

            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(_mapper));
        }

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IMapper _mapper;   

        public async Task<IdentityResult> InsertAsync(ApplicationRoleDTO applicationRoleDTO)
        {
            var identityRole = _mapper.Map<IdentityRole>(applicationRoleDTO);

            var result = await _roleManager.CreateAsync(identityRole);

            return result;
        }

        public async Task<IdentityResult> RemoveAsync(string id)
        {
            var identityRole = _roleManager.Roles.FirstOrDefault(role => role.Id == id);

            var result = await _roleManager.DeleteAsync(identityRole);

            return result;
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationRoleDTO applicationRoleDTO)
        {
            var identityRole = _mapper.Map<IdentityRole>(applicationRoleDTO);

            var result = await _roleManager.UpdateAsync(identityRole);

            return result;
        }

        public async Task<IdentityResult> AddCalimAsync(ApplicationRoleDTO applicationRoleDTO)
        {
            var identityRole = _mapper.Map<IdentityRole>(applicationRoleDTO);

            var claim = new IdentityRoleClaim<string>() 
            {
                RoleId = identityRole.Id,
                ClaimType = ClaimTypes.Role,
                ClaimValue = applicationRoleDTO.Name,
            };

            var result = await _roleManager.AddClaimAsync(identityRole, claim.ToClaim());

            return result;
        }
    }
}