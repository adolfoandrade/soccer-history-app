using App.Domain.Exceptions.SoccerTeam;
using App.Service.Interfaces;
using App.Service.ViewModels.SoccerTeam;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
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

        [HttpPost(nameof(UploadFile))]
        public async Task<IActionResult> UploadFile(IFormFile files)
        {
            string systemFileName = files.FileName;
            string blobstorageconnection = "DefaultEndpointsProtocol=https;AccountName=soccer;AccountKey=bTLerzicIaITKhTlxVx0QVYpfB/ymB76o2915zEu0hgFWbNdju6HdQUQi9KfhObtY+b+ImzRFzpFVhbilm8zbQ==;EndpointSuffix=core.windows.net";
            // Retrieve storage account from connection string.    
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            // Create the blob client.    
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // Retrieve a reference to a container.    
            CloudBlobContainer container = blobClient.GetContainerReference("teams");
            // This also does not make a service call; it only creates a local object.    
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
            await using (var data = files.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }
            return Ok("File Uploaded Successfully");
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
