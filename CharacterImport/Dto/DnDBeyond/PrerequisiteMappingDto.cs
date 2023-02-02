namespace CharacterImport.Dto.DnDBeyond
{
    public class PrerequisiteMappingDto
    {
        public long Id { get; set; }
        public long EntityType { get; set; }
        public long EntityTypeId { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public long Value { get; set; }
        public string FriendlyTypeName { get; set; }
        public string FriendlkySubTypeName { get; set; }
    }
}
