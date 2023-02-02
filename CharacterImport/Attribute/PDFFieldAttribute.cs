namespace CharacterImport.Attribute
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class PDFFieldAttribute : System.Attribute
    {
        public string FieldName { get; private set; }

        public PDFFieldAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}
