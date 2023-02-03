using AutoMapper;
using Model.Db;
using Model.Dto;

namespace Model.Mapping
{
    public partial class MappingProfile : Profile
    {
        public void MapBracket()
        {
            CreateMap<Bracket, BracketDto>()
                .ReverseMap();
        }
    }
}