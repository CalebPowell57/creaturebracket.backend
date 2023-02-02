using CharacterImport.Attribute;

namespace CharacterImport.Dto
{
    public class InventoryDto
    {
        public string Name { get; set; }

        [PDFField("qty")]
        public string Quantity { get; set; }

        public string Weight { get; set; }
    }
}
