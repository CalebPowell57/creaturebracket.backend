using Model.Db;
using Model.Db.Interfaces;

namespace Model.Dto.Post
{
    public class UserMatchupDto : UserMatchup, IUpdate
    {
        public new long? Id { get; set; }
        //public new Creature? Creature1 { get; set; }
        //public new Creature? Creature2 { get; set; }
        //public new Creature? Winner { get; set; }
    }
}