namespace Model.Db
{
    public class CreatureSubmission : DataModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public long BracketId { get; set; }

        public IEnumerable<CreatureSubmissionVote> Votes { get; set; }
    }
}