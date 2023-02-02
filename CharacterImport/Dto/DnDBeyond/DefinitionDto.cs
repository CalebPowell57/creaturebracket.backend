namespace CharacterImport.Dto.DnDBeyond
{
    public class DefinitionDto
    {
        public long Id { get; set; }
        public long EntityTypeId { get; set; }
        public string DefinitionKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string SkillProficienciesDescription { get; set; }
        public string ToolProficienciesDescription { get; set; }
        public string EquipmentDescription { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public string AvatarUrl { get; set; }
        public string LargeAvatarUrl { get; set; }
        public string SuggestedCharacteristicsDescription { get; set; }
        public string Organization { get; set; }
        public string ContractsDescription { get; set; }
        public string SpellsPreDescription { get; set; }
        public IEnumerable<TraitDto> PersonalityTraits { get; set; }
        public IEnumerable<IdealDto> Ideals { get; set; }
        public IEnumerable<BondDto> Bonds { get; set; }
        public IEnumerable<FlawDto> Flaws { get; set; }
        public bool IsHomebrow { get; set; }
        //spelllistids
    }
}
