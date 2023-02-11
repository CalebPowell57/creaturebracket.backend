using AutoMapper;
using Model.Db;
using Model.Dto;

namespace Model.Mapping
{
    public partial class MappingProfile : Profile
    {
        public void MapUserMatchup()
        {
            CreateMap<UserMatchup, UserMatchupDto>()
                .ReverseMap();

            CreateMap<Dto.Post.UserMatchupDto, UserMatchup>()
                .ReverseMap();
        }
    }
}