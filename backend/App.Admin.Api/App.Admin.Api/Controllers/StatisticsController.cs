using App.Domain.Exceptions.SoccerTeamEventCard;
using App.Domain.Exceptions.SoccerTeamEventGoal;
using App.Domain.Exceptions.Statistic;
using App.Service.Interfaces;
using App.Service.ViewModels.Statistic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace App.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<StatisticsController> _logger;
        private readonly IStatisticGoalsService _statisticsGoalsService;
        private readonly IStatisticCardsService _statisticsCardsService;
        private readonly ICommonStatisticService _commonStatisticService;

        public StatisticsController(ILogger<StatisticsController> logger,
            IStatisticGoalsService statisticsGoalsService,
            IStatisticCardsService statisticsCardsService,
            ICommonStatisticService commonStatisticService)
        {
            _logger = logger;
            _statisticsGoalsService = statisticsGoalsService;
            _statisticsCardsService = statisticsCardsService;
            _commonStatisticService = commonStatisticService;
        }

        [HttpPost("goals")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post(AddStatisticGoalsVM request)
        {
            try
            {
                var result = await _statisticsGoalsService.AddAsync(request);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (AddSoccerTeamEventGoalsException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("cards")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post(AddStatisticCardsVM request)
        {
            try
            {
                var result = await _statisticsCardsService.AddAsync(request);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (AddSoccerTeamEventCardException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("common")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post(AddCommonStatisticVM request)
        {
            try
            {
                var result = await _commonStatisticService.AddAsync(request);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (AddStatisticException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
