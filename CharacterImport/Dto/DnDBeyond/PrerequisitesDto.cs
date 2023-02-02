namespace CharacterImport.Dto.DnDBeyond
{
    public class PrerequisitesDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<PrerequisiteMappingDto> PrerequisiteMappings { get; set; }
    }
}
