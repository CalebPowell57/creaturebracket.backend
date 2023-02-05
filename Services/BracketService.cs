using AutoMapper;
using Db;
using Microsoft.EntityFrameworkCore;
using Model.Db;
using Model.Dto;

namespace Service
{
    public class BracketService : DataService<Bracket>
    {
        public BracketService(CreatureBracketContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<BracketDto> GetActive()
        {
            var brackets = await _dbSet
                .Include(c => c.Creatures)
                .Include(c => c.Matchups)
                .Include(c => c.UserMatchups)
                .Include(c => c.CreatureSubmissions)
                .ToListAsync();

            var bracket = brackets.First();//fix this

            var dto = _mapper.Map<BracketDto>(bracket);

            return dto;
        }

        public async Task<IEnumerable<StandingsDto>> GetStandings(long bracketId)
        {
            var bracket = await _dbSet
                .Include(c => c.Creatures)
                .Include(c => c.Matchups)
                .Include(c => c.UserMatchups)
                .Include(c => c.CreatureSubmissions)
                .SingleAsync(x => x.Id == bracketId);

            var standings = new List<StandingsDto>();

            foreach(var userMatchups in bracket.UserMatchups.GroupBy(x => x.User))
            {
                var standing = new StandingsDto
                {
                    User = userMatchups.First().User,                    
                };

                foreach (var userMatchup in userMatchups)
                {
                    var matchup = bracket.Matchups.Single(x => x.Rank == userMatchup.Rank && x.Round == userMatchup.Round);

                    standing.Points += matchup.WinnerId == userMatchup.WinnerId ? 1 * matchup.Round : 0;
                }

                standings.Add(standing);
            }

            return standings;
        }
    }
}