using Microsoft.EntityFrameworkCore;
using Model.Db;

namespace Db
{
    public class CreatureBracketContext : DbContext
    {
        public DbSet<Bracket> Bracket { get; set; }
        public DbSet<Creature> Creature { get; set; }
        public DbSet<CreatureSubmission> CreatureSubmission { get; set; }
        public DbSet<CreatureSubmissionVote> CreatureSubmissionVote { get; set; }
        public DbSet<Matchup> Matchup { get; set; }
        public DbSet<UserMatchup> UserMatchup { get; set; }

        public DbContextOptions<CreatureBracketContext> Options { get; }

        public CreatureBracketContext(DbContextOptions<CreatureBracketContext> options) : base(options)
        {
            Options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
