using Eedi.Api.Controllers;
using Eedi.Business.Contract;
using Eedi.Business.Entities;
using Eedi.Utils;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Eedi.UnitTests.Controller
{
    public class ImproveControllerTests
    {
        private readonly Mock<IImproveService> _mockImproveService;
        private readonly ImproveController _improveController;

        public ImproveControllerTests()
        {
            Mock<ILogger<ImproveController>> mockLoggerImproveController = new();
            _mockImproveService = new Mock<IImproveService>();
            _improveController = new ImproveController(_mockImproveService.Object, mockLoggerImproveController.Object);
        }

        [Fact(DisplayName = "Returns OkObjectResult When Improve Found")]
        public async Task ReturnsOkObjectResultWhenImproveFound()
        {
            // Arrange
            const string userName = "Test";
            var improve = Data.GetImproveWithMisconception();
            
            _mockImproveService.Setup(x => x.GetImproveWithMisconceptionAsync(
                It.IsAny<string>())).ReturnsAsync(improve);

            // Act
            var result = await _improveController.GetImproveWithMisconceptionAsync(userName);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            ((ObjectResult)result.Result).Value.Should().BeOfType<Improve>();
            ((ObjectResult)result.Result)?.StatusCode.Should().Be(200);
            ((ObjectResult)result.Result)?.Value.Should().BeEquivalentTo(improve, x=> x.ExcludingMissingMembers());
            _mockImproveService.Verify(x => x.GetImproveWithMisconceptionAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact(DisplayName = "Returns NotFoundObjectResult When Improve Not Found")]
        public async Task ReturnsNotFoundObjectResultWhenSearchListNotFound()
        {
            // Arrange
            const string userName = "Test";
            Improve? improve = null;
            _mockImproveService.Setup(x => x.GetImproveWithMisconceptionAsync(
                It.IsAny<string>())).ReturnsAsync(improve);

            // Act
            var result = await _improveController.GetImproveWithMisconceptionAsync(userName);

            // Assert
            result.Result.Should().BeOfType<NotFoundObjectResult>();
            ((ObjectResult)result.Result)?.StatusCode.Should().Be(404);
            ((ObjectResult)result.Result)?.Value.Should().Be("Improve not found");
            _mockImproveService.Verify(x => x.GetImproveWithMisconceptionAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact(DisplayName = "Returns BadRequestObjectResult When UserName Not Valid For Improve")]
        public async Task ReturnsBadRequestObjectResultWhenUserNameNotValidForImprove()
        {
            // Arrange
            const string userName = "";

            // Act
            var result = await _improveController.GetImproveWithMisconceptionAsync(userName);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
            ((ObjectResult)result.Result)?.StatusCode.Should().Be(400);
            ((ObjectResult)result.Result)?.Value.Should().Be("Invalid UserName");
            _mockImproveService.Verify(x => x.GetImproveWithMisconceptionAsync(It.IsAny<string>()), Times.Never);
        }

        [Theory(DisplayName = "Returns OkObjectResult When Misconception Answer Is Valid And Updated Successfully")]
        [MemberData(nameof(MisconceptionAnswerValidData))]
        public async Task ReturnsOkObjectResultWhenMisconceptionAnswerValidAndUpdated(MisconceptionAnswer validMisconceptionAnswer)
        {
            // Arrange
            var improve = Data.GetImproveWithMisconception();
            _mockImproveService.Setup(x => x.UpdateMisconceptionAnswerAsync(
                It.IsAny<MisconceptionAnswer>())).ReturnsAsync(improve);

            // Act
            var result = await _improveController.UpdateMisconceptionAnswerAsync(validMisconceptionAnswer);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            ((ObjectResult)result.Result)?.Value.Should().BeOfType<Improve>();
            ((ObjectResult)result.Result)?.StatusCode.Should().Be(200);
            ((ObjectResult)result.Result)?.Value.Should().BeEquivalentTo(improve, x=> x.ExcludingMissingMembers());
            _mockImproveService.Verify(x => x.UpdateMisconceptionAnswerAsync(It.IsAny<MisconceptionAnswer>()), Times.Once);
        }

        [Theory(DisplayName = "Returns BadRequestObjectResult When Misconception Answer Not Valid For Update")]
        [MemberData(nameof(MisconceptionAnswerInvalidData))]
        public async Task ReturnsBadRequestObjectResultWhenMisconceptionAnswerNotValidForUpdate(MisconceptionAnswer invalidMisconceptionAnswer)
        {
            // Arrange
            var improve = Data.GetImproveWithMisconception();
            _mockImproveService.Setup(x => x.UpdateMisconceptionAnswerAsync(
                It.IsAny<MisconceptionAnswer>())).ReturnsAsync(improve);

            // Act
            var result = await _improveController.UpdateMisconceptionAnswerAsync(invalidMisconceptionAnswer);
            
            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
            ((ObjectResult)result.Result)?.StatusCode.Should().Be(400);
            ((ObjectResult)result.Result)?.Value.Should().Be($"Invalid Misconception Answer { invalidMisconceptionAnswer.Answer }");
            _mockImproveService.Verify(x => x.UpdateMisconceptionAnswerAsync(It.IsAny<MisconceptionAnswer>()), Times.Never);
        }

        public static IEnumerable<object[]> MisconceptionAnswerInvalidData =>
            new List<object[]>
            {
                new object[] { new MisconceptionAnswer
                {
                    Answer = "a", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
                new object[] { new MisconceptionAnswer
                {
                    Answer = "b", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
                new object[] { new MisconceptionAnswer
                {
                    Answer = "c", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
                new object[] { new MisconceptionAnswer
                {
                    Answer = "d", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
                new object[] { new MisconceptionAnswer
                {
                    Answer = "E", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
                new object[] { new MisconceptionAnswer
                {
                    Answer = "e", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
            };

        public static IEnumerable<object[]> MisconceptionAnswerValidData =>
            new List<object[]>
            {
                new object[] { new MisconceptionAnswer
                {
                    Answer = "A", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
                new object[] { new MisconceptionAnswer
                {
                    Answer = "B", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
                new object[] { new MisconceptionAnswer
                {
                    Answer = "C", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
                new object[] { new MisconceptionAnswer
                {
                    Answer = "D", TopicId = 1, SubTopicId = 1, MisconceptionId = 1, UserId = 1, AnswerText = "The correct sequence is -16, -4, -1, -31"
                }},
            };
    }
}
