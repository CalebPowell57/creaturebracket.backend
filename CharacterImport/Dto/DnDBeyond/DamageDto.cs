namespace CharacterImport.Dto.DnDBeyond
{
    public class DamageDto
    {
        public long? DiceCount { get; set; }
        public long? DiceValue { get; set; }
        public long? DiceMultiplier { get; set; }
        public long? FixedValue { get; set; }
        public string DiceString { get; set; }
    }
}
