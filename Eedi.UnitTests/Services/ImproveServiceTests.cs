using Eedi.Business;
using Eedi.Business.Contract;
using Eedi.Business.Entities;
using Eedi.Utils;
using FluentAssertions;

namespace Eedi.UnitTests.Services
{
    public class ImproveServiceTests
    {
        private readonly IImproveService _improveService;

        public ImproveServiceTests()
        {
            _improveService = new ImproveService();
        }        

        [Fact(DisplayName = "Get Improve Successfully")]
        public async Task GetImproveSuccessfully()
        {
            // Arrange
            const int userId = 1;
            var improve = Data.Improve;

            // Act
            var actual = await _improveService.GetImproveAsync(userId);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeOfType<Improve>();
            actual.Should().BeEquivalentTo(improve, x => x.ExcludingMissingMembers());
            actual.Topics.Should().HaveCount(2);
        }

        [Fact(DisplayName = "Get Question Successfully")]
        public async Task GetQuestionSuccessfully()
        {
            // Arrange
            const int topicId = 1;
            const int subTopicId = 1;
            const int questionId = 1;
            var question = Data.Question;

            // Act
            var actual = await _improveService.GetQuestionAsync(topicId, subTopicId, questionId);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeOfType<Question>();
            actual.Should().BeEquivalentTo(question, x => x.ExcludingMissingMembers());
            actual.Id.Should().Be(question.Id);
        }

        [Theory(DisplayName = "Update Answer When Answer Option Is Valid And Updated Successfully")]
        [MemberData(nameof(Data.AnswerValidOption), MemberType = typeof(Data))]        
        public async Task UpdateAnswerWhenAnswerOptionValidAndUpdated(Answer answerValidOption)
        {
            // Act
            var actual = await _improveService.UpdateAnswerAsync(answerValidOption);
            var verification = Data.Verification;

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeOfType<Verification>();
            actual.Should().BeEquivalentTo(verification, x => x.ExcludingMissingMembers());
            actual.Id.Should().Be(verification.Id);
        }

        [Theory(DisplayName = "Update Answer Throws Exception When Answer Option Not Valid For Update")]
        [MemberData(nameof(Data.AnswerInValidOption), MemberType = typeof(Data))]
        public async Task UpdateAnswerThrowsExceptionWhenAnswerOptionNotValidForUpdate(Answer answerInValidOption)
        {
            // Act, Assert
            var actual = async () => { await _improveService.UpdateAnswerAsync(answerInValidOption); };
            await actual.Should().ThrowAsync<ArgumentException>("Answer option is invalid");
        }
    }
}
