namespace CharacterImport.Attribute
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class PDFDefaultValueAttribute : System.Attribute
    {
        public object DefaultValue { get; private set; }

        public PDFDefaultValueAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}
