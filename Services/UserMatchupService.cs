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

            var bracket = await _context.Bracket
                .Include(x => x.Matchups)
                    .ThenInclude(x => x.Creature1)
                .Include(x => x.Matchups)
                    .ThenInclude(x => x.Creature2)
                .SingleAsync(x => x.Id == bracketId);

            var roundMatchupCount = bracket.CreatureCount;
            var round = 0;

            if (!userMatchups.Any())
            {
                while (roundMatchupCount != 1)
                {
                    round++;
                    roundMatchupCount = roundMatchupCount / 2;

                    for (var index = 0; index < roundMatchupCount; index++)
                    {
                        var matchup = new UserMatchupDto
                        {
                            Rank = index + 1,
                            Round = round,
                            BracketId = bracketId,
                            User = user,
                        };

                        if (round == 1)
                        {
                            var actualMatchup = bracket.Matchups.SingleOrDefault(x => x.Round == round && x.Rank == index + 1);

                            if (actualMatchup != null)
                            {
                                matchup.Creature1Id = actualMatchup.Creature1Id;
                                matchup.Creature2Id = actualMatchup.Creature2Id;
                                matchup.Creature1 = actualMatchup.Creature1;
                                matchup.Creature2 = actualMatchup.Creature2;
                            }
                        }

                        userMatchups.Add(matchup);
                    }
                }
            }

            var dto = _mapper.Map<List<UserMatchupDto>>(userMatchups);

            return dto;
        }

        public void Save(string user, long bracketId, IEnumerable<UserMatchupDto> userMatchupDtos)
        {
            var dtos = userMatchupDtos.Select(x => new UserMatchupDto
            {
                BracketId = bracketId,
                User = user,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = user,
                Creature1Id = x.Creature1Id,
                Creature2Id = x.Creature2Id,
                Id = x.Id,
                Rank = x.Rank,
                Round = x.Round,
                WinnerId = x.WinnerId,
            });

            Upsert(dtos);
        }
    }
}