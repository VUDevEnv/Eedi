using Eedi.Business.Contract;
using Eedi.Business.Entities;

namespace Eedi.Business
{
    public class ImproveService : IImproveService
    {
        public async Task<Improve?> GetImproveAsync(string userName)
        {
            var improve = new Improve
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

            return await Task.FromResult(improve);
        }        

        public async Task<MisconceptionAnswer> UpdateMisconceptionAnswerAsync(MisconceptionAnswer misconceptionAnswer)
        {
             return await Task.FromResult(misconceptionAnswer);
        }
    }
}
