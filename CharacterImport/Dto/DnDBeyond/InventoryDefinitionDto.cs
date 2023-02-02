namespace CharacterImport.Dto.DnDBeyond
{
    public class InventoryDefinitionDto
    {
        public long Id { get; set; }
        public long EntityTypeId { get; set; }
        public InventoryDto Definition { get; set; }
        public long Quantity { get; set; }
        public bool IsAttuned { get; set; }
        public bool Equipped { get; set; }
        public long ChargesUsed { get; set; }
        public long? LimitedUse { get; set; }
        public string Currency { get; set; }
    }
}
