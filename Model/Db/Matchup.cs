namespace Model.Db
{
    public class Matchup : DataModel
    {
        public long Round { get; set; }
        public long Rank { get; set; }
        public long? WinnerId { get; set; }
        public long? Creature1Id { get; set; }
        public long? Creature2Id { get; set; }
        public long BracketId { get; set; }

        public Creature Creature1 { get; set; }
        public Creature Creature2 { get; set; }
        public Creature Winner { get; set; }
    }
}