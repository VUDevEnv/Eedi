using Eedi.Business.Entities;

namespace Eedi.Utils
{
    public static class Data
    {
        public static Improve Improve =>
            new Improve
            {
                Id = 1,
                Topics =
                [
                    new Topic
                    {
                        Id = 1,
                        Name = "Number",
                        SubTopics =
                        [
                            new SubTopic
                            {
                                Id = 1,
                                Name = "Decimals",
                                QuestionCount = 2
                            }
                        ]
                    },
                    new Topic
                    {
                        Id = 2,
                        Name = "Algebra",
                        SubTopics =
                        [
                            new SubTopic
                            {
                                Id = 3,
                                Name = "Fractions",
                                QuestionCount = 1
                            }
                        ]
                    }
                ]
            };

        public static Question Question =>
            new Question
            {
                Id = 1,
                TopicId = 1,
                SubTopicId = 1,
                QuestionImageUrl = "Question Image URL",
                AnswerOptions = Enum.GetValues(typeof(AnswerOption))
                    .Cast<AnswerOption>()
                    .Select(v => v.ToString())
                    .ToList()
            };

        public static IEnumerable<object[]> AnswerValidOption =>
            new List<object[]>
            {
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "A"
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "B"
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "C"
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "D"
                }},
            };

        public static IEnumerable<object[]> AnswerInValidOption =>
            new List<object[]>
            {
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "a"
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "b"
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "c"
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "d"
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "E"
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = "e"
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = ""
                }},
                new object[] { new Answer
                {
                    TopicId = 1, SubTopicId = 1, QuestionId = 1, Option = null
                }},
            };

        public static Verification Verification =>
            new Verification
            {
                Id = 1,
                TopicId = 1,
                SubTopicId = 1,
                QuestionId = 1,
                AnswerOption = "B",
                Correct = true,
                Explanation = "The correct sequence is -16, 13, -10, -7, -4"
            };
    }
}
