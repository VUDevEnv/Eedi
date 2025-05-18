using Eedi.Business.Contract;
using Eedi.Business.Entities;
using Eedi.Utils;

namespace Eedi.Business
{
    public class ImproveService : IImproveService
    {
        public async Task<Improve?> GetImproveAsync(int improveId)
        {
            // Get Improve by Id, contains misconception/s data.
            var result = Data.Improve;
            return await Task.FromResult(result);
        }

        public async Task<Question?> GetQuestionAsync(int topicId, int subTopicId, int questionId)
        {
            // Get Question by topicId, subTopicId and questionId.
            var result = Data.Question;
            return await Task.FromResult(result);
        }

        public async Task<Verification> UpdateAnswerAsync(Answer answer)
        {
            if (answer.Option != null && ValidEnum(answer.Option))
            {
                // Update Verification
                var result = Data.Verification;
                return await Task.FromResult(result);
            }
            else
            {
                throw new ArgumentException("Answer option is invalid", nameof(answer.Option));
            }
        }

        public bool ValidEnum(string option)
        {
            return Enum.TryParse(option, out AnswerOption _) && Enum.IsDefined(typeof(AnswerOption), option);
        }
    }
}
