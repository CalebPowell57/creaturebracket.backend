namespace CharacterImport.Attribute
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class PDFTableAttribute : System.Attribute
    {
        public string Name { get; private set; }

        public PDFTableAttribute(string name)
        { 
            Name = name;
        }
    }
}
