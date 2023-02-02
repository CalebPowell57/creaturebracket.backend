namespace CharacterImport.Dto.DnDBeyond
{
    public class RacialTraitDto
    {
        public long Id { get; set; }
        public string DefinitionKey { get; set; }
        public long EntityTypeId { get; set; }
        public long DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Snippit { get; set; }
        //public string spellListIds { get; set; }
        public long? RequiredLevel { get; set; }
    }
}
