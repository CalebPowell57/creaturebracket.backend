using AutoMapper;
using Db;
using Microsoft.EntityFrameworkCore;
using Model.Db;
using Model.Dto;

namespace Service
{
    public class UserMatchupService : DataService<UserMatchup>
    {
        public UserMatchupService(CreatureBracketContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<IEnumerable<UserMatchupDto>> Get(string user, long bracketId)
        {
            var userMatchups = await _dbSet
                .Include(c => c.Creature1)
                .Include(c => c.Creature2)
                .Include(c => c.Winner)
                .Where(x => x.User == user && x.BracketId == bracketId)
                .ToListAsync();

            var bracket = await _context.Bracket.SingleAsync(x => x.Id == bracketId);

            var dto = _mapper.Map<List<UserMatchupDto>>(userMatchups);

            var roundMatchupCount = bracket.CreatureCount;

            if (!userMatchups.Any())
            {
                for(int roundIndex = 0; roundIndex < bracket.RoundCount; roundIndex++)
                {
                    roundMatchupCount = roundMatchupCount / 2;

                    for (int matchupIndex = 0; matchupIndex < roundMatchupCount; matchupIndex++)
                    {
                        var matchup = new UserMatchupDto
                        {
                            BracketId = bracketId,
                            Creature1Id = null,
                            Creature2Id = null,
                            Rank = matchupIndex + 1,
                            Round = roundIndex + 1,
                            User = user,
                        };

                        dto.Add(matchup);
                    }
                }
            }

            return dto;
        }
    }
}