namespace CharacterImport.Attribute
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class PDFWhitespaceToBoolAttribute : System.Attribute
    {
        public PDFWhitespaceToBoolAttribute() {}
    }
}
