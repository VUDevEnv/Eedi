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

        [Fact(DisplayName = "Get Improve Throws Exception When Username Is Invalid(")]
        public async Task GetImproveThrowsExceptionWhenUsernameInvalid()
        {
            // Arrange
            const string userName = "";

            // Act, Assert
            var act = async () => { await _improveService.GetImproveWithMisconceptionAsync(userName); };
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact(DisplayName = "Get Improve Successfully")]
        public async Task GetImproveSuccessfully()
        {
            // Arrange
            const string userName = "Test";
            var improve = Data.GetImproveWithMisconception();

            // Act
            var result = await _improveService.GetImproveWithMisconceptionAsync(userName);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Improve>();
            result.Should().BeEquivalentTo(improve, x => x.ExcludingMissingMembers());
            result.Topics.Should().HaveCount(2);
        }

        [Theory(DisplayName = "Update Misconception Answer Throws Exception When Misconception Answer Is Invalid")]
        [MemberData(nameof(MisconceptionAnswerInvalidData))]
        public async Task UpdateMisconceptionAnswerThrowsExceptionWhenMisconceptionAnswerInvalid(MisconceptionAnswer invalidMisconceptionAnswer)
        {
            // Act, Assert
            var act = async () => { await _improveService.UpdateMisconceptionAnswerAsync(invalidMisconceptionAnswer); };
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Theory(DisplayName = "Update Misconception Answer Successfully")]
        [MemberData(nameof(MisconceptionAnswerValidData))]
        public async Task UpdateMisconceptionAnswerSuccessfully(MisconceptionAnswer validMisconceptionAnswer)
        {
            // Act
            var result = await _improveService.UpdateMisconceptionAnswerAsync(validMisconceptionAnswer);
            var improve = Data.GetImproveWithMisconception();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Improve>();
            result.Should().BeEquivalentTo(improve, x => x.ExcludingMissingMembers());
            result.Topics.Should().HaveCount(2);
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
