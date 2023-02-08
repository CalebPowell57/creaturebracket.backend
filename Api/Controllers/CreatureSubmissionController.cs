using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Service;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class CreatureSubmissionController : ControllerBase
    {
        private readonly ILogger<CreatureSubmissionController> _logger;
        private readonly CreatureSubmissionService _creatureSubmissionService;

        public CreatureSubmissionController(ILogger<CreatureSubmissionController> logger, CreatureSubmissionService creatureSubmissionService)
        {
            _logger = logger;
            _creatureSubmissionService = creatureSubmissionService;
        }

        [HttpGet("{bracketId}")]
        public async Task<IEnumerable<CreatureSubmissionDto>> Get([FromRoute] long bracketId)
        {
            var creatureSubmissions = await _creatureSubmissionService.Get(bracketId);

            return creatureSubmissions;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] CreatureSubmissionDto creatureSubmissionDto)
        {
            _creatureSubmissionService.Upsert(creatureSubmissionDto);
            await _creatureSubmissionService.SaveChanges();

            return true;
        }
    }
}