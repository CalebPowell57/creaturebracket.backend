using System.Collections.Generic;

namespace CharacterImport.Dto.DnDBeyond
{
    public class InventoryDto
    {
        public long Id { get; set; }
        public long BaseTypeId { get; set; }
        public long EntityTypeId { get; set; }
        public string DefinitionKey { get; set; }
        public bool CanEquip { get; set; }
        public bool Magic { get; set; }
        public string Name { get; set; }
        public string Snippet { get; set; }
        public long Weight { get; set; }
        public long WeightMultiplier { get; set; }
        public long? Capacity { get; set; }
        public long CapacityWeight { get; set; }
        public string Description { get; set; }
        public bool CanAttune { get; set; }
        public string AttunementDescription { get; set; }
        public string Rarity { get; set; }
        public bool Stackable { get; set; }
        public bool BundleSize { get; set; }
        public string AvatarUrl { get; set; }
        public string LargeAvatarUrl { get; set; }
        public string FilterType { get; set; }
        public double Cost { get; set; }
        public bool IsPack { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<object> GrantedModifiers { get; set; }
                    //subType: null,
        public bool IsConsumable { get; set; }
                    //weaponBehaviors: [],
        public long? BaseItemId { get; set; }
        public string BaseArmorName { get; set; }
                    //strengthRequirement: null,
        public long? ArmorClass { get; set; }
        public long? StealthCheck { get; set; }
        public DamageDto Damage { get; set; }
        public long? CategoryId { get; set; }
        public long? Range { get; set; }
        public long? LongRange { get; set; }
        public bool? IsMonkWeapon { get; set; }
        public long? LevelInfusionGranted { get; set; }
        public long? ArmorTypeId { get; set; }
        public long? GearTypeId { get; set; }
        public long? GroupedId { get; set; }
        public bool CanBeAddedToInventory { get; set; }
        public bool IsContainer { get; set; }
        public bool IsCustomItem { get; set; }
    }
}
