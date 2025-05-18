using Eedi.Business.Contract;
using Eedi.Business.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eedi.Api.Controllers
{
    /// <summary>
    /// ImproveController handles HTTP requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
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
        /// Get improve with misconception/s by ID.
        /// </summary>
        /// <param name="improveId"></param>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("{improveId}")]
        public async Task<ActionResult<Improve>> GetImproveAsync([FromRoute]int improveId)
        {
            try
            {
                var improve = await _improveService.GetImproveAsync(improveId);

                if (improve == null)                
                    return NotFound("Improve not found");               

                return Ok(improve);   
            }
            catch(Exception ex)
            {                
                _logger.LogError(ex, $"Error occurred retrieving improve for Id {improveId}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred retrieving improve");
            }            
        }

        /// <summary>
        /// Get question by TopicId, SubTopicId and QuestionId.
        /// </summary> 
        /// <param name="topicId"></param>
        /// <param name="subTopicId"></param>
        /// <param name="questionId"></param>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("question")]
        public async Task<ActionResult<Question>> GetQuestionAsync([FromQuery] int topicId, int subTopicId, int questionId)
        {
            try
            {
                var question = await _improveService.GetQuestionAsync(topicId, subTopicId, questionId);

                if (question == null)
                    return NotFound("Question not found");

                return Ok(question);
            }
            catch(Exception ex)
            {                
                _logger.LogError(
                    ex, $"Error occurred retrieving question {questionId}, topic {topicId}, subTopic {subTopicId}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred retrieving question");
            }            
        }  

        /// <summary>
        /// Stores the updated answer for a specific user (A,B,C,D).
        /// </summary>
        /// <returns></returns>
        /// <response code="400">BadRequest</response>
        /// <response code="200">OK</response> 
        /// <response code="500">InternalServerError</response>
        [HttpPut("answer")]
        public async Task<ActionResult<Verification>> UpdateAnswerAsync([FromBody]Answer answer)
        {
            try
            {
                if (answer.Option != null && _improveService.ValidEnum(answer.Option))
                {
                    var verification = await _improveService.UpdateAnswerAsync(answer);

                    return Ok(verification);
                }

                return BadRequest($"Invalid answer option {answer.Option}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    $"Error occurred updating answer option {answer.Option}, question {answer.QuestionId}, topic {answer.TopicId}, subTopic {answer.SubTopicId}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred updating answer");
            }

            //bool IsDefined(string option)
            //{
            //    return Enum.TryParse(option, out AnswerOption _) && Enum.IsDefined(typeof(AnswerOption), option);
            //}
        }
    }
}
