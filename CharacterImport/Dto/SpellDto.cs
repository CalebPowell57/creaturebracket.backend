using CharacterImport.Attribute;

namespace CharacterImport.Dto
{
    public class SpellDto
    {
        public string Prepared { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }

        [PDFField("savehit")]
        public string Save { get; set; } 
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Page { get; set; }
        public string Notes { get; set; }
    }
}
