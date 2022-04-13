using App.Domain.Exceptions.Competition;
using App.Service.Interfaces;
using App.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
        private readonly ILogger<CompetitionsController> _logger;
        private readonly ICompetitionService _service;

        public CompetitionsController(ILogger<CompetitionsController> logger,
            ICompetitionService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{season}")]
        [ProducesResponseType(typeof(List<CompetitionVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetByCompetition(string season)
        {
            try
            {
                var result = await _service.GetBySeasonAsync(season);
                return Ok(result);
            }
            catch (QueryCompetitionBySeasonException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(CompetitionVM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post(CompetitionVM request)
        {
            try
            {
                var result = await _service.AddAsync(request);
                return Ok(result);
            }
            catch (AddCompetitionException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(CompetitionVM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(CompetitionVM request)
        {
            try
            {
                var result = await _service.UpdateAsync(request);
                return Ok(result);
            }
            catch (CompetitionNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UpdateCompetitionException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(List<CompetitionVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                return Ok(result);
            }
            catch (DeleteCompetitionException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
