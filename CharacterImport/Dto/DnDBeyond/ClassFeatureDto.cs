namespace CharacterImport.Dto.DnDBeyond
{
    public class ClassFeatureDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long RequiredLevel { get; set; }
        public long DisplayOrder { get; set; }
    }
}
