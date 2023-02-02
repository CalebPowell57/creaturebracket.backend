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
    }
}