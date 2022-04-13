using App.Domain.Exceptions.SoccerEvent;
using App.Service.Interfaces;
using App.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace App.Admin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly ISoccerEventService _service;

        public EventsController(ILogger<EventsController> logger,
            ISoccerEventService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("matches/{match}")]
        [ProducesResponseType(typeof(SoccerEventMatchVM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetByMatch(string match)
        {
            try
            {
                var result = await _service.GetByMatchAsync(match);
                return Ok(result);
            }
            catch (QueryByMatchSoccerEventException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet("seasoning/{competitionId}/{season}")]
        [ProducesResponseType(typeof(SoccerEventMatchVM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetBySeason(int competitionId, string season)
        {
            try
            {
                var result = await _service.GetBySeasonAsync(competitionId, season);
                return Ok(result);
            }
            catch (QueryBySeasonSoccerEventException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(CompetitionVM), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post(AddSoccerEventVM request)
        {
            try
            {
                var result = await _service.AddAsync(request);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (AddSoccerEventException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
