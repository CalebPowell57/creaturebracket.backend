namespace CharacterImport.Attribute
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class PDFSectionAttribute : System.Attribute
    {
        public string FieldName { get; private set; }
        public string SectionName { get; private set; }

        public PDFSectionAttribute(string fieldName, string sectionName)
        {
            FieldName = fieldName;
            SectionName = sectionName;
        }
    }
}
