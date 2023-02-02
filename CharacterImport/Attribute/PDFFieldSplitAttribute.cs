namespace CharacterImport.Attribute
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class PDFSplitAttribute : System.Attribute
    {
        public string NameSeparator { get; private set; }
        public string ValueSeparator { get; private set; }

        public PDFSplitAttribute(string fieldSeparator, string valueSeparator)
        {
            NameSeparator = fieldSeparator;
            ValueSeparator = valueSeparator;
        }
    }
}
