using AutoMapper;
using WorkShop.Web.Dto;
using WorkShop.Web.Model;

namespace WorkShop.Web.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemsDto>().ReverseMap();
        }
    }
}
