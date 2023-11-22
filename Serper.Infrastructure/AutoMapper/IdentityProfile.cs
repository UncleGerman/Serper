using AutoMapper;
using Serper.BLL.Entity.Authorization;
using Serper.BLL.Entity.Identity;
using Serper.DAL.Entity.Identity;

namespace Serper.Infrastructure.AutoMapper
{
    internal sealed class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<ApplicationUserDTO, ApplicationUser>().ReverseMap();

            CreateMap<IRegistration, ApplicationUserDTO>()
                .ForMember(a => a.PasswordHash, opt => opt.MapFrom(r => r.Password));
        }
    }
}