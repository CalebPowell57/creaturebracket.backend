namespace CharacterImport.Dto.DnDBeyond
{
    public class BackgroundDto
    {
        public bool HasCustomBackground { get; set; }
        public DefinitionDto Definition { get; set; }
        public long? DefinitionId { get; set; }
        public CustomBackgroundDto CustomBackground { get; set; }
    }
}
