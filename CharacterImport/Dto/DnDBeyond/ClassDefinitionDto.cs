namespace CharacterImport.Dto.DnDBeyond
{
    public class ClassDefinitionDto
    {
        public long Id { get; set; }
        public long EntityTypeId { get; set; }
        public long Level { get; set; }
        public bool IsStartingClass { get; set; }
        public long HitDiceUsed { get; set; }
        public long DefinitionId { get; set; }
        public long SubclassDefinitionId { get; set; }
        public ClassDto Definition { get; set; }
    }
}
