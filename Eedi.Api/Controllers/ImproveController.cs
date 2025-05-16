using Eedi.Business.Contract;
using Eedi.Business.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eedi.Api.Controllers
{
    /// <summary>
    /// ImproveController handles HTTP requests for improve.
    /// </summary>
    public class ImproveController : ControllerBase
    {
        private readonly IImproveService _improveService;
        private readonly ILogger<ImproveController> _logger;               

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="improveService"></param>
        /// <param name="logger"></param>
        public ImproveController(
            IImproveService improveService, 
            ILogger<ImproveController> logger) 
        {  
            _improveService = improveService; 
            _logger = logger;
        }

        /// <summary>
        /// Get improve details for a specific user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <response code="400">BadRequest</response>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        [HttpGet("improve")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Improve>> GetImproveAsync(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))                
                    return BadRequest("Invalid UserName");                

                var improve = await _improveService.GetImproveAsync(userName);

                if (improve == null)                
                    return NotFound("Improve not found");               

                return Ok(improve);   
            }
            catch(Exception ex)
            {                
                _logger.LogError(ex, $"Error Occurred Retrieving Improve For User {userName}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occurred Retrieving Improve");
            }            
        }        

        /// <summary>
        /// Stores the updated misconception answer for a specific user (A,B,C,D)
        /// </summary>
        /// <returns></returns>
        /// <response code="400">BadRequest</response>
        /// <response code="200">OK</response>
        [HttpPut("misconceptionAnswer")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MisconceptionAnswer>> UpdateMisconceptionAnswerAsync(MisconceptionAnswer misconceptionAnswer)
        {
            try
            {
                if (Enum.TryParse(misconceptionAnswer.Answer, out AnswerOption _) 
                    && Enum.IsDefined(typeof(AnswerOption), misconceptionAnswer.Answer))
                {
                    var updatedMisconceptionAnswer =
                        await _improveService.UpdateMisconceptionAnswerAsync(misconceptionAnswer);

                    return Ok(updatedMisconceptionAnswer);
                }

                return BadRequest($"Invalid Misconception Answer {misconceptionAnswer.Answer}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    $"Error Occurred Updating Misconception {misconceptionAnswer.MisconceptionId} For User {misconceptionAnswer.UserId}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occurred Retrieving Improve");
            }
        }
    }
}
