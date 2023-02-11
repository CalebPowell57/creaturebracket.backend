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
        public async Task<IEnumerable<Bracket>> Get()
        {
            var bracket = await _bracketService.Get();

            return bracket;
        }

        [HttpGet("standings/{bracketId}")]
        public async Task<IEnumerable<StandingsDto>> GetStandings([FromRoute] long bracketId)
        {
            var standings = await _bracketService.GetStandings(bracketId);

            return standings;
        }

        [HttpGet("{bracketId}/randomseed")]
        public async Task<IEnumerable<SeedItemDto>> GetRandomSeed([FromRoute] long bracketId)
        {
            var randomSeed = await _bracketService.GetRandomSeed(bracketId);

            return randomSeed;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] Model.Dto.Post.BracketDto bracket)
        {
            _bracketService.NewBracket(bracket);

            await _bracketService.SaveChanges();

            return true;
        }

        [HttpPost("{bracketId}/saveseed")]
        public async Task<bool> SaveSeed([FromRoute] long bracketId, [FromBody] List<SeedItemDto> seedings)
        {
            _bracketService.SaveSeeding(bracketId, seedings);

            await _bracketService.SaveChanges();

            return true;
        }

        [HttpPost("{bracketId}/battle")]
        public async Task<bool> Battle([FromRoute] long bracketId)
        {
            _bracketService.Battle(bracketId);

            await _bracketService.SaveChanges();

            return true;
        }
    }
}