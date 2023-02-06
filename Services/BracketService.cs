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

        public void NewBracket(Model.Dto.Post.BracketDto dto)
        {
            var bracket = _mapper.Map<Bracket>(dto);

            var roundCreatureCount = dto.CreatureCount;
            var round = 0;
            var matchups = new List<Matchup>();

            while (roundCreatureCount != 1)
            {
                round++;
                roundCreatureCount = roundCreatureCount / 2;

                for (var index = 0; index < roundCreatureCount; index++)
                {
                    var matchup = new Matchup
                    {
                        Rank = index + 1,
                        Round = round,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = "calebpowell57",
                    };

                    matchups.Add(matchup);
                }
            }

            bracket.Matchups = matchups;

            Upsert(bracket);
        }
    }
}