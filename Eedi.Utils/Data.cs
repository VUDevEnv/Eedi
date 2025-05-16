using Eedi.Business.Entities;

namespace Eedi.Utils
{
    public static class Data
    {
        public static Improve GetImprove() =>
            new Improve
            {
                UserId = 1,
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
                                Misconceptions =
                                [
                                    new Misconception
                                    {
                                        Id = 1,
                                        QuestionImage = string.Empty,
                                        AnswerOptions = Enum.GetValues(typeof(AnswerOption))
                                            .Cast<AnswerOption>()
                                            .Select(v => v.ToString())
                                            .ToList()
                                    },
                                    new Misconception
                                    {
                                        Id = 2,
                                        QuestionImage = string.Empty,
                                        AnswerOptions = Enum.GetValues(typeof(AnswerOption))
                                            .Cast<AnswerOption>()
                                            .Select(v => v.ToString())
                                            .ToList()
                                    }
                                ]
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
                                Id = 1,
                                Name = "Fractions",
                                Misconceptions =
                                [
                                    new Misconception
                                    {
                                        Id = 1,
                                        QuestionImage = string.Empty,
                                        AnswerOptions = Enum.GetValues(typeof(AnswerOption))
                                            .Cast<AnswerOption>()
                                            .Select(v => v.ToString())
                                            .ToList()
                                    }
                                ]
                            }
                        ]
                    }
                ]
            };
    }
}
