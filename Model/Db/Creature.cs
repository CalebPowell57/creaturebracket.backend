namespace Model.Db
{
    public class Creature : DataModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public long BracketId { get; set; }
    }
}