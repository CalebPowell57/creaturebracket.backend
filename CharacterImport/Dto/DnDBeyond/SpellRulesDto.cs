namespace CharacterImport.Dto.DnDBeyond
{
    public class SpellRulesDto
    {
        public long MultiClassSpellSlotDivisor { get; set; }
        public bool IsRitualSpellCaster { get; set; }
        public IEnumerable<long> LevelCantripsKnownMaxes { get; set; }
        public IEnumerable<long> LevelSpellKnownMaxes { get; set; }
        public IEnumerable<IEnumerable<long>> LevelSpellSlots { get; set; }
        public long MultiClassSpellSlotRounding { get; set; }
    }
}
