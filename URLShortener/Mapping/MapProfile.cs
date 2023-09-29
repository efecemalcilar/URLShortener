using AutoMapper;
using URLShortener.Models;

namespace URLShortener.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UrlManagement, UrlDto>().ReverseMap();
            

        }
    }
}
