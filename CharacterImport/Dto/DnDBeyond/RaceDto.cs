namespace CharacterImport.Dto.DnDBeyond
{
    public class RaceDto
    {
        public bool IsSubRace { get; set; }
        public string BaseRaceName { get; set; }
        public long EntityRaceId { get; set; }
        public long EntityRaceType { get; set; }
        public string DefinitionKey { get; set; }
        public string FullName { get; set; }
        public long BaseRaceId { get; set; }
        public long BaseRaceTypeId { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public string LargeAvatarUrl { get; set; }
        public string PortraitAvatarUrl { get; set; }
        public string MoreDetailsUrl { get; set; }
        public bool IsHomebrew { get; set; }
        public IEnumerable<long> GroupIds { get; set; }
        public long Type { get; set; }
        public string SubRaceShortName { get; set; }
        public string baseName { get; set; }
        public IEnumerable<RacialTraitDefinitionDto> RacialTraits { get; set; }
        public WeightSpeedsDto WeightSpeeds { get; set; }
    }
}
