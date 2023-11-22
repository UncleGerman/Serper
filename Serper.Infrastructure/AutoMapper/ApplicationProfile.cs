using AutoMapper;
using Serper.API.Entity;
using Serper.BLL.Entity;
using Serper.DAL.Entity;

namespace Serper.Infrastructure.AutoMapper
{
    internal sealed class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<SearchResult, SearchResultDTO>().ReverseMap();
            
            CreateMap<Organic, SearchResult>();
        }
    }
}