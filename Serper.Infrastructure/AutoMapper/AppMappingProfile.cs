using AutoMapper;
using Serper.BLL.Entity;
using Serper.DAL.Entity;
using Serper.DAL.Entity.Identity;

namespace Serper.Infrastructure.AutoMapper
{
    internal sealed class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<SearchRequest, SearchRequestDTO>().ReverseMap();

            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
        }
    }
}