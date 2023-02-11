using AutoMapper;

namespace Model.Mapping
{
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapBracket();
            MapCreatureSubmission();
            MapUserMatchup();
        }
    }
}
