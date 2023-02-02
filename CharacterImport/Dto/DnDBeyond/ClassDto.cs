namespace CharacterImport.Dto.DnDBeyond
{
    public class ClassDto
    {
        public long Id { get; set; }
        public string DefinitionKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EquipmentDescription { get; set; }
        public long? ParentClassId { get; set; }
        public string AvatarUrl { get; set; }
        public string LargeAvatarUrl { get; set; }
        public string PortraitAvatarUrl { get; set; }
        public string MoreDetailsUrl { get; set; }
        public long? SpellCastingAbilityId { get; set; }
        public IEnumerable<ClassFeatureDto> ClassFeatures { get; set; }
        public long HitDice { get; set; }
        public WealthDiceDto WealthDice { get; set; }
        public bool CanCastSpells { get; set; }
        public IEnumerable<long> PrimaryAbilities { get; set; }
        public SpellRulesDto SpellRules { get; set; }
        public PrerequisitesDto Prerequisites { get; set; }
    }
}
