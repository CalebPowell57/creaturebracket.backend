using AutoMapper;
using Model.Db;
using Model.Dto;

namespace Model.Mapping
{
    public partial class MappingProfile : Profile
    {
        public void MapCreatureSubmission()
        {
            CreateMap<CreatureSubmission, CreatureSubmissionDto>()
                .ReverseMap();

            CreateMap<Dto.Post.CreatureSubmissionDto, CreatureSubmission>()
                .ReverseMap();
        }
    }
}