using Eedi.Business.Entities;

namespace Eedi.Business.Contract
{
    public interface IImproveService
    {
        Task<Improve?> GetImproveAsync(int improveId);     
        Task<Question?> GetQuestionAsync(int topicId, int subTopicId, int questionId);   
        Task<Verification> UpdateAnswerAsync(Answer answer);
        bool ValidEnum(string option);
    }
}
