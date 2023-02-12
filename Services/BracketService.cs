using AutoMapper;
using Db;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Db;
using Model.Dto;

namespace Service
{
    public class BracketService : DataService<Bracket>
    {
        public BracketService(CreatureBracketContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<IEnumerable<BracketDto>> Get()
        {
            var brackets = await _dbSet
                .Include(c => c.Creatures)
                .Include(c => c.Matchups)
                .Include(c => c.UserMatchups)
                .Include(c => c.CreatureSubmissions)
                .ToListAsync();

            var dto = _mapper.Map<IEnumerable<BracketDto>>(brackets);

            return dto;
        }

        public async Task<IEnumerable<StandingsDto>> GetStandings(long bracketId)
        {
            var bracket = await _dbSet
                .Include(b => b.UserMatchups)
                .Include(b => b.Matchups)
                .SingleAsync(b => b.Id == bracketId);

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

                    var points = Math.Pow(2, matchup.Round - 1) == 0 ? 1 : (int)Math.Pow(2, matchup.Round - 1);

                    standing.Points += matchup.WinnerId.HasValue && matchup.WinnerId == userMatchup.WinnerId ? points : 0;
                }

                standings.Add(standing);
            }

            return standings;
        }

        public async Task<IEnumerable<SeedItemDto>> GetRandomSeed(long bracketId)
        {
            var bracket = await _dbSet
                .Include(c => c.CreatureSubmissions)
                    .ThenInclude(cs => cs.Votes)
                .SingleAsync(x => x.Id == bracketId);

            if (bracket.CreatureCount > bracket.CreatureSubmissions.Count())
            {
                throw new Exception($"Unable to seed {bracket.Name}. Not enough creature submissions {bracket.CreatureSubmissions.Count()}/{bracket.CreatureCount}");
            }

            var randomSeeds = new List<(long Seed, string Name, long CreatureSubmissionId)>();
            var currentSeed = 1;

            foreach (var creatureSubmissionGroup in bracket.CreatureSubmissions.GroupBy(x => x.Votes.Count()).OrderByDescending(c => c.Key))
            {
                var random = new Random();
                foreach (var creatureSubmission in creatureSubmissionGroup.OrderBy(x => random.Next()))
                {
                    (long Seed, string Name, long CreatureSubmissionId) seedItem = new(currentSeed, creatureSubmission.Name, creatureSubmission.Id);

                    randomSeeds.Add(seedItem);

                    currentSeed++;
                }
            }

            var seed = new List<SeedItemDto>();

            for (var index = 0; index < bracket.CreatureCount / 2; index++)
            {
                var creature1 = randomSeeds.Single(x => x.Seed == index + 1);
                var creature2 = randomSeeds.Single(x => x.Seed == bracket.CreatureCount - index);

                var seedItem = new SeedItemDto
                {
                    Creature1SubmissionId = creature1.CreatureSubmissionId,
                    Creature2SubmissionId = creature1.CreatureSubmissionId,
                    Creature1Name = creature1.Name,
                    Creature2Name = creature2.Name,
                    Creature1Seed = creature1.Seed,
                    Creature2Seed = creature2.Seed,
                };

                seed.Add(seedItem);
            }

            return seed;
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
            bracket.Round = 1;
            bracket.Phase = Constants.BracketPhase.CreatureSubmission;

            Upsert(bracket);
        }

        public void SaveSeeding(long bracketId, List<SeedItemDto> seedings)
        {
            var bracket = _dbSet
                .Include(b => b.Matchups)
                .Include(b => b.CreatureSubmissions)
                    .ThenInclude(cs => cs.Votes)
                .Single(x => x.Id == bracketId)
            ;

            bracket.Phase = Constants.BracketPhase.Seeded;

            var matchups = seedings.Select(s => new Matchup
            {
                Creature1 = new Creature
                {
                    Name = s.Creature1Name,
                    BracketId = bracketId,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "calebpowell57",
                    Image = "",
                    Seed = s.Creature1Seed,
                    Votes = bracket.CreatureSubmissions.Single(cs => cs.Id == s.Creature1SubmissionId).Votes.Count(),
                },
                BracketId = bracketId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "calebpowell57",
                Creature2 = new Creature
                {
                    Name = s.Creature2Name,
                    BracketId = bracketId,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "calebpowell57",
                    Image = "",
                    Seed = s.Creature2Seed,
                    Votes = bracket.CreatureSubmissions.Single(cs => cs.Id == s.Creature2SubmissionId).Votes.Count(),
                },
                Rank = seedings.IndexOf(s) + 1,
                Round = 1,
            }).ToList();

            var matchupCount = bracket.CreatureCount / 2;
            var round = 1;

            while (matchupCount != 1)
            {
                matchupCount /= 2;
                round++;

                for (var index = 0; index < matchupCount; index++)
                {
                    var matchup = new Matchup
                    {
                        BracketId = bracketId,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = "calebpowell57",
                        Round = round,
                        Rank = index + 1,
                    };

                    matchups.Add(matchup);
                }
            }

            _context.Matchup.AddRange(matchups);

            Upsert(bracket);
        }

        public void Battle(long bracketId)
        {
            var bracket = _dbSet
                .Include(b => b.Matchups)
                .Single(x => x.Id == bracketId)
            ;

            var isFinished = false;

            foreach(var matchup in bracket.Matchups.Where(x => x.Round == bracket.Round))
            {
                //matchup.Creature1.Votes;
                matchup.WinnerId = matchup.Creature1Id;//

                var nextMatchup = bracket.Matchups.SingleOrDefault(x => x.Rank == Math.Ceiling((double)matchup.Rank / 2) && x.Round == bracket.Round + 1);

                if (nextMatchup is not null)
                {
                    var isFirst = ((double)matchup.Rank / 2) % 1 != 0;

                    if (isFirst)
                    {
                        nextMatchup.Creature1Id = matchup.WinnerId;
                    }
                    else
                    {
                        nextMatchup.Creature2Id = matchup.WinnerId;
                    }

                    _context.Matchup.Update(nextMatchup);
                }
                else
                {
                    isFinished = true;
                }
            }

            if (!isFinished)
            {
                bracket.Round++;
            }

            Upsert(bracket);
        }
    }
}