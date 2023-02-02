using AutoMapper;
using Model.Db;
using Model.Dto;

namespace Model.Mapping
{
    public partial class MappingProfile : Profile
    {
        //public void MapCampaign()
        //{
        //    CreateMap<Campaign, CampaignDto>()
        //        .ForMember(d => d.Characters, o => o.Ignore())
        //        .ForMember(d => d.CharacterCount, o => o.MapFrom(x => x.Characters.Count()))
        //        .ForMember(d => d.CharacterId, o => o.MapFrom(x => x.Characters.Last().Id))
        //        .ReverseMap();
        //}
    }
}