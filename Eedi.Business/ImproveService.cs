using Eedi.Business.Contract;
using Eedi.Business.Entities;
using Eedi.Utils;

namespace Eedi.Business
{
    public class ImproveService : IImproveService
    {
        public async Task<Improve?> GetImproveWithMisconceptionAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("UserName cannot be null or whitespace.", nameof(userName));
            
            var improve = Data.GetImproveWithMisconception();

            return await Task.FromResult(improve);
        }

        public async Task<MisconceptionAnswer> UpdateMisconceptionAnswerAsync(MisconceptionAnswer misconceptionAnswer)
        {
            if (Enum.TryParse(misconceptionAnswer.Answer, out AnswerOption answerOption)
                && Enum.IsDefined(typeof(AnswerOption), misconceptionAnswer.Answer))
                return await Task.FromResult(misconceptionAnswer);
            else
                throw new ArgumentException("Misconception Answer is invalid", nameof(misconceptionAnswer.Answer));
        }
    }
}
