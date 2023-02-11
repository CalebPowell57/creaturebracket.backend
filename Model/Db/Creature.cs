namespace Model.Db
{
    public class Creature : DataModel
    {
        public long Seed { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public long BracketId { get; set; }
        public long Votes { get; set; }
    }
}