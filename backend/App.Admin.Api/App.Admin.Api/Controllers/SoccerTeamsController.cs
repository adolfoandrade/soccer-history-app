using App.Domain.Exceptions.SoccerTeam;
using App.Service.Interfaces;
using App.Service.ViewModels.SoccerTeam;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoccerTeamsController : ControllerBase
    {
        private readonly ILogger<SoccerTeamsController> _logger;
        private readonly ISoccerTeamService _service;

        public SoccerTeamsController(ILogger<SoccerTeamsController> logger,
            ISoccerTeamService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("filter/{filter}")]
        [ProducesResponseType(typeof(IEnumerable<SoccerTeamVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get(string filter)
        {
            try
            {
                var result = await _service.FilterAsync(filter);
                return Ok(result);
            }
            catch (QuerySoccerTeamException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SoccerTeamVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _service.GetAsync();
                return Ok(result);
            }
            catch (QuerySoccerTeamException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SoccerTeamVM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(int), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _service.GetAsync(id);
                return Ok(result);
            }
            catch (QuerySoccerTeamException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
