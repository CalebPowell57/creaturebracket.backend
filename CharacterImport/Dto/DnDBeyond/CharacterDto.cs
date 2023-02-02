namespace CharacterImport.Dto.DnDBeyond
{
    public class CharacterDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Faith { get; set; }
        public long Age { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Skin { get; set; }
        public string Height { get; set; }
        public bool Inspiration { get; set; }
        public long Weight { get; set; }
        public long BaseHitPoints { get; set; }
        public long? BonusHitPoints { get; set; }
        public long RemovedHitPoints { get; set; }
        public long TemporaryHitPoints { get; set; }
        public long CurrentXp { get; set; }
        public long AlignmentId { get; set; }
        public long LifestyleId { get; set; }
        public IEnumerable<StatDto> Stats { get; set; }
        public IEnumerable<StatDto> BonusStats { get; set; }
        public IEnumerable<StatDto> OverrideStats { get; set; }
        public BackgroundDto Background { get; set; }
        public RaceDto Race { get; set; }
        //notes
        public TraitsDto Traits { get; set; }
        public ConfigurationDto Configuration { get; set; }
        //lifestyle
        public IEnumerable<InventoryDefinitionDto> Inventory { get; set; }
        public CurrenciesDto Currencies { get; set; }
        public IEnumerable<ClassDto> Classes { get; set; }
        public DeathSavesDto DeathSaves { get; set; }
        public IEnumerable<SpellSlotDto> SpellSlots { get; set; }
        public IEnumerable<PactMagicDto> PactMagic { get; set; }
        public IEnumerable<long> ActiveSourceCategories { get; set; }
        public SpellsDto Spells { get; set; }
        public OptionsDto Options { get; set; }
        public ChoicesDto Choices { get; set; }
    }
}
