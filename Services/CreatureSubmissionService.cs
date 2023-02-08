using AutoMapper;
using Db;
using Microsoft.EntityFrameworkCore;
using Model.Db;
using Model.Dto;

namespace Service
{
    public class CreatureSubmissionService : DataService<CreatureSubmission>
    {
        public CreatureSubmissionService(CreatureBracketContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<IEnumerable<CreatureSubmissionDto>> Get(long bracketId)
        {
            var creatureSubmissions = await _dbSet
                .Include(x => x.Votes)
                .Where(x => x.BracketId == bracketId)
                .ToListAsync();

            var dto = _mapper.Map<IEnumerable<CreatureSubmissionDto>>(creatureSubmissions);

            return dto;
        }
    }
}