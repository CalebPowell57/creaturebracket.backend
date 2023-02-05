using Microsoft.AspNetCore.Mvc;
using Model.Db;
using Model.Dto;
using Service;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class BracketController : ControllerBase
    {
        private readonly ILogger<BracketController> _logger;
        private readonly BracketService _bracketService;

        public BracketController(ILogger<BracketController> logger, BracketService bracketService)
        {
            _logger = logger;
            _bracketService = bracketService;
        }

        [HttpGet]
        public async Task<Bracket> Get()
        {
            var bracket = await _bracketService.GetActive();

            return bracket;
        }

        [HttpGet("standings/{bracketId}")]
        public async Task<IEnumerable<StandingsDto>> GetStandings([FromRoute] long bracketId)
        {
            var standings = await _bracketService.GetStandings(bracketId);

            return standings;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] Model.Dto.Post.BracketDto bracket)
        {
            for (var index = 0; index < bracket.CreatureCount / 2; index++)
            {

            }

            _bracketService.Upsert(bracket);

            await _bracketService.SaveChanges();

            return true;
        }
    }
}