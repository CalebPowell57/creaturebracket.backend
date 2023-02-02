using CharacterImport.Attribute;

namespace CharacterImport.Dto
{
    public class CharacterDto
    {
        [PDFIgnore]
        public string ExternalId { get; set; }

        [PDFSplit("&", " ")]
        public string Class { get; set; }

        [PDFSplit("&", " ")]
        public long Level { get; set; }

        //[PDFRace]
        //[PDFIgnore]// shouldn't be here
        public string Race { get; set; }

        [PDFField("race")]
        public string Subrace { get; set; }
        public string Background { get; set; }
        //public string BackgroundDescription { get; set; }

        [PDFIgnore]// shouldn't be here
        public long ExperiencePoints { get; set; }

        [PDFField("ST Strength")]
        public long Strength { get; set; }

        [PDFField("ST Dexterity")]
        public long Dexterity { get; set; }

        [PDFField("ST Constitution")]
        public long Constitution { get; set; }

        [PDFField("ST Intelligence")]
        public long Intelligence { get; set; }

        [PDFField("ST Wisdom")]
        public long Wisdom { get; set; }

        [PDFField("ST charisma")]
        public long Charisma { get; set; }

        #region Skills
        public long Acrobatics { get; set; }

        [PDFField("Animal")]
        public long AnimalHandling { get; set; }
        public long Arcana { get; set; }
        public long Athletics { get; set; }
        public long Deception { get; set; }
        public long History { get; set; }
        public long Insight { get; set; }
        public long Intimidation { get; set; }
        public long Investigation { get; set; }
        public long Medicine { get; set; }
        public long Nature { get; set; }
        public long Perception { get; set; }
        public long Performance { get; set; }
        public long Persuasion { get; set; }
        public long Religion { get; set; }
        public long SleightOfHand { get; set; }
        public long Stealth { get; set; }
        public long Survival { get; set; }

        [PDFField("AcrobaticsProf")]
        [PDFWhitespaceToBool]
        public bool IsAcrobaticsProficient { get; set; }

        [PDFField("AnimalHandlingProf")]
        [PDFWhitespaceToBool]
        public bool IsAnimalHandlingProficient { get; set; }

        [PDFField("ArcanaProf")]
        [PDFWhitespaceToBool]
        public bool IsArcanaProficient { get; set; }

        [PDFField("AthleticsProf")]
        [PDFWhitespaceToBool]
        public bool IsAthleticsProficient { get; set; }

        [PDFField("DeceptionProf")]
        [PDFWhitespaceToBool]
        public bool IsDeceptionProficient { get; set; }

        [PDFField("HistoryProf")]
        [PDFWhitespaceToBool]
        public bool IsHistoryProficient { get; set; }

        [PDFField("InsightProf")]
        [PDFWhitespaceToBool]
        public bool IsInsightProficient { get; set; }

        [PDFField("IntimidationProf")]
        [PDFWhitespaceToBool]
        public bool IsIntimidationProficient { get; set; }

        [PDFField("InvestigationProf")]
        [PDFWhitespaceToBool]
        public bool IsInvestigationProficient { get; set; }

        [PDFField("MedicineProf")]
        [PDFWhitespaceToBool]
        public bool IsMedicineProficient { get; set; }

        [PDFField("NatureProf")]
        [PDFWhitespaceToBool]
        public bool IsNatureProficient { get; set; }

        [PDFField("PerceptionProf")]
        [PDFWhitespaceToBool]
        public bool IsPerceptionProficient { get; set; }

        [PDFField("PerformanceProf")]
        [PDFWhitespaceToBool]
        public bool IsPerformanceProficient { get; set; }

        [PDFField("PersuasionProf")]
        [PDFWhitespaceToBool]
        public bool IsPersuasionProficient { get; set; }

        [PDFField("ReligionProf")]
        [PDFWhitespaceToBool]
        public bool IsReligionProficient { get; set; }

        [PDFField("SleightOfHandProf")]
        [PDFWhitespaceToBool]
        public bool IsSleightOfHandProficient { get; set; }

        [PDFField("StealthProf")]
        [PDFWhitespaceToBool]
        public bool IsStealthProficient { get; set; }

        [PDFField("SurvivalProf")]
        [PDFWhitespaceToBool]
        public bool IsSurvivalProficient { get; set; }
        #endregion

        #region Initiative
        [PDFField("Init")]
        public long InitiativeModifier { get; set; }

        [PDFField("AC")]
        public long ArmorClass { get; set; }

        public string Speed { get; set; }

        [PDFIgnore]
        public bool HasInspiration { get; set; }

        [PDFField("ProfBonus")]
        public long ProficiencyBonus { get; set; }

        [PDFField("MaxHP")]
        public long MaxHitPoints { get; set; }

        [PDFField("MaxHP")]// only doing this bc dnd beyond doesn't export current hp (I assume it's ok to make this assumption)
        public long CurrentHitPoints { get; set; }

        [PDFField("TempHP")]
        [PDFDefaultValue(0)]
        public long TemporaryHitPoints { get; set; }
        //ac should be calculated

        [PDFField("STRmod")]
        public long StrengthModifier { get; set; }

        [PDFField("DEXmod")]
        public long DexterityModifier { get; set; }

        [PDFField("CONmod")]
        public long ConstitutionModifier { get; set; }

        [PDFField("INTmod")]
        public long IntelligenceModifier { get; set; }

        [PDFField("WISmod")]
        public long WisdomModifier { get; set; }

        [PDFField("CHAmod")]
        public long CharismaModifier { get; set; }
        #endregion

        #region Death Saves
        [PDFIgnore]
        public long FailCount { get; set; }

        [PDFIgnore]
        public long SuccessCount { get; set; }

        [PDFIgnore]
        public bool IsStabilized { get; set; }
        #endregion

        //proficiencies & lanquages

        //actions

        [PDFField("AdditionalSenses")]
        public string Senses { get; set; }

        #region Inventory
        [PDFTable("eq ")]
        public IEnumerable<InventoryDto> Inventory { get; set; }
        #endregion

        //features & traits

        #region Currency
        [PDFField("CP")]
        public long Copper { get; set; }

        [PDFField("SP")]
        public long Silver { get; set; }

        [PDFField("EP")]
        public long Electrum { get; set; }

        [PDFField("GP")]
        public long Gold { get; set; }

        [PDFField("PP")]
        public long Platinum { get; set; }
        #endregion

        #region About
        [PDFField("charactername")]
        public string Name { get; set; }

        public string Gender { get; set; }

        public string Faith { get; set; }

        public string Alignment { get; set; }

        public long Age { get; set; }

        public string Hair { get; set; }

        public string Eyes { get; set; }

        public string Skin { get; set; }

        public string Height { get; set; }

        public long Weight { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }

        [PDFField("ProficienciesLang")]
        public string Proficiencies { get; set; }

        [PDFField("FeaturesTraits1")]
        public string FeaturesAndTraits1 { get; set; }

        [PDFField("FeaturesTraits2")]
        public string FeaturesAndTraits2 { get; set; }

        [PDFSection("alliesorganizations", "allies")]
        public string Allies { get; set; }

        [PDFSection("alliesorganizations", "organizations")]
        public string Organizations { get; set; }

        public string Backstory { get; set; }

        [PDFField("AdditionalNotes1")]
        public string Notes { get; set; }
        #endregion

        [PDFTable("spell")]
        public IEnumerable<SpellDto> Spells { get; set; }

        [PDFField("spellCastingAbility0")]
        public string SpellCastingAbility { get; set; }

        [PDFField("spellSaveDC0")]
        public long SpellSavingDC { get; set; }

        [PDFField("spellAtkBonus0")]
        public long SpellAttackBonus { get; set; }
    }
}
