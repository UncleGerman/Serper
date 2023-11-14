using AutoMapper;
using Serper.BLL.Entity;
using Serper.DAL.Entity;

namespace Serper.Infrastructure.AutoMapper
{
    internal sealed class AppMappingProfile : Profile
    {
        protected AppMappingProfile()
        {
            CreateMap<Search, SearchDTO>().ReverseMap();
        }
    }
}