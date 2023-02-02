using Microsoft.AspNetCore.Mvc;
using Model.Db;
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
    }
}