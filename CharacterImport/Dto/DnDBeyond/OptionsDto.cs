namespace CharacterImport.Dto.DnDBeyond
{
    public class OptionsDto
    {
        public IEnumerable<object> Race { get; set; }
        public IEnumerable<object> Class { get; set; }
        public IEnumerable<object> Item { get; set; }
        public IEnumerable<object> Feat { get; set; }
    }
}
