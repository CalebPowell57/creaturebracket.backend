namespace CharacterImport.Dto.DnDBeyond
{
    public class ChoicesDto
    {
        public IEnumerable<object> Race { get; set; }
        public IEnumerable<object> Class { get; set; }
        public IEnumerable<object> Background { get; set; }
        public IEnumerable<object> Item { get; set; }
        public IEnumerable<object> Feat { get; set; }
    }
}
