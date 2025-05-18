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
            const int userId = 1;
            var improve = Data.Improve;

            _mockImproveService.Setup(x => x.GetImproveAsync(
                It.IsAny<int>())).ReturnsAsync(improve);

            // Act
            var actual = await _improveController.GetImproveAsync(userId);

            // Assert
            actual.Result.Should().BeOfType<OkObjectResult>();
            ((ObjectResult)actual.Result).Value.Should().BeOfType<Improve>();
            ((ObjectResult)actual.Result)?.StatusCode.Should().Be(200);
            ((ObjectResult)actual.Result)?.Value.Should().BeEquivalentTo(improve, x => x.ExcludingMissingMembers());
            _mockImproveService.Verify(x => x.GetImproveAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "Returns NotFoundObjectResult When Improve Not Found By UserId")]
        public async Task ReturnsNotFoundObjectResultWhenImproveNotFound()
        {
            // Arrange
            const int userId = 1;
            Improve? improve = null;
            _mockImproveService.Setup(x => x.GetImproveAsync(
                It.IsAny<int>())).ReturnsAsync(improve);

            // Act
            var actual = await _improveController.GetImproveAsync(userId);

            // Assert
            actual.Result.Should().BeOfType<NotFoundObjectResult>();
            ((ObjectResult)actual.Result)?.StatusCode.Should().Be(404);
            ((ObjectResult)actual.Result)?.Value.Should().Be("Improve not found");
            _mockImproveService.Verify(x => x.GetImproveAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "Returns OkObjectResult When Question Found By TopicId, SubTopicId and QuestionId")]
        public async Task ReturnsOkObjectResultWhenQuestionFound()
        {
            // Arrange
            const int topicId = 1;
            const int subTopicId = 1;
            const int questionId = 1;
            var question = Data.Question;

            _mockImproveService.Setup(x => x.GetQuestionAsync(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(question);

            // Act
            var actual = await _improveController.GetQuestionAsync(topicId, subTopicId, questionId);

            // Assert
            actual.Result.Should().BeOfType<OkObjectResult>();
            ((ObjectResult)actual.Result).Value.Should().BeOfType<Question>();
            ((ObjectResult)actual.Result)?.StatusCode.Should().Be(200);
            ((ObjectResult)actual.Result)?.Value.Should().BeEquivalentTo(question, x => x.ExcludingMissingMembers());
            _mockImproveService.Verify(x => x.GetQuestionAsync(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact(DisplayName = "Returns NotFoundObjectResult When Question Not Found By TopicId, SubTopicId and QuestionId")]
        public async Task ReturnsNotFoundObjectResultWhenQuestionNotFound()
        {
            // Arrange
            const int topicId = 1;
            const int subTopicId = 1;
            const int questionId = 1;
            Question? question = null;
            _mockImproveService.Setup(x => x.GetQuestionAsync(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(question);

            // Act
            var actual = await _improveController.GetQuestionAsync(topicId, subTopicId, questionId);

            // Assert
            actual.Result.Should().BeOfType<NotFoundObjectResult>();
            ((ObjectResult)actual.Result)?.StatusCode.Should().Be(404);
            ((ObjectResult)actual.Result)?.Value.Should().Be("Question not found");
            _mockImproveService.Verify(x => x.GetQuestionAsync(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Theory(DisplayName = "Returns OkObjectResult When Answer Option Is Valid And Updated Successfully")]
        [MemberData(nameof(Data.AnswerValidOption), MemberType = typeof(Data))]
        public async Task ReturnsOkObjectResultWhenAnswerOptionValidAndUpdated(Answer answerValidOption)
        {
            // Arrange
            var verification = Data.Verification;
            bool validEnum = true;
            _mockImproveService.Setup(x => x.UpdateAnswerAsync(
                It.IsAny<Answer>())).ReturnsAsync(verification);
            _mockImproveService.Setup(x => x.ValidEnum(
                It.IsAny<string>())).Returns(validEnum);

            // Act
            var actual = await _improveController.UpdateAnswerAsync(answerValidOption);

            // Assert
            actual.Result.Should().BeOfType<OkObjectResult>();
            ((ObjectResult)actual.Result)?.Value.Should().BeOfType<Verification>();
            ((ObjectResult)actual.Result)?.StatusCode.Should().Be(200);
            ((ObjectResult)actual.Result)?.Value.Should().BeEquivalentTo(
                verification, x => x.ExcludingMissingMembers());
            _mockImproveService.Verify(x => x.UpdateAnswerAsync(It.IsAny<Answer>()), Times.Once);
        }

        [Theory(DisplayName = "Returns BadRequestObjectResult When Answer Option Not Valid For Update")]
        [MemberData(nameof(Data.AnswerInValidOption), MemberType = typeof(Data))]
        public async Task ReturnsBadRequestObjectResultWhenAnswerOptionNotValidForUpdate(Answer answerInValidOption)
        {
            // Arrange
            var verification = Data.Verification;
            _mockImproveService.Setup(x => x.UpdateAnswerAsync(
                It.IsAny<Answer>())).ReturnsAsync(verification);

            // Act
            var actual = await _improveController.UpdateAnswerAsync(answerInValidOption);

            // Assert
            actual.Result.Should().BeOfType<BadRequestObjectResult>();
            ((ObjectResult)actual.Result)?.StatusCode.Should().Be(400);
            ((ObjectResult)actual.Result)?.Value.Should().Be($"Invalid answer option {answerInValidOption.Option}");
            _mockImproveService.Verify(x => x.UpdateAnswerAsync(It.IsAny<Answer>()), Times.Never);
        }
    }
}
