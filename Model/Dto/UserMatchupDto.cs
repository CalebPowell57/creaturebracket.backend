using Model.Db;
using Model.Db.Interfaces;

namespace Model.Dto
{
    public class UserMatchupDto : UserMatchup, IUpdate
    {
        public new long? Id { get; set; }
    }
}