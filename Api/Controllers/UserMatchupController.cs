using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Service;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class UserMatchupController : ControllerBase
    {
        private readonly ILogger<UserMatchupController> _logger;
        private readonly UserMatchupService _userMatchupService;

        public UserMatchupController(ILogger<UserMatchupController> logger, UserMatchupService userMatchupService)
        {
            _logger = logger;
            _userMatchupService = userMatchupService;
        }

        [HttpGet("{user}/{bracketId}")]
        public async Task<IEnumerable<UserMatchupDto>> Get([FromRoute] string user, long bracketId)
        {
            var userMatchups = await _userMatchupService.Get(user, bracketId);

            return userMatchups;
        }

        [HttpPost("{user}/{bracketId}")]
        public async Task<bool> Post([FromRoute] string user, [FromRoute] long bracketId, [FromBody] IEnumerable<UserMatchupDto> userMatchups)
        {
            _userMatchupService.Save(user, bracketId, userMatchups);

            await _userMatchupService.SaveChanges();

            return true;
        }
    }
}