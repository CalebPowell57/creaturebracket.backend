namespace Model.Db
{
    public class Bracket : DataModel
    {
        public string Name { get; set; }
        public long RoundCount { get; set; }
        public long CreatureCount { get; set; }
        public string Phase { get; set; }

        public IEnumerable<Matchup> Matchups { get; set; }
        public IEnumerable<UserMatchup> UserMatchups { get; set; }
        public IEnumerable<Creature> Creatures { get; set; }
        public IEnumerable<CreatureSubmission> CreatureSubmissions { get; set; }
    }
}