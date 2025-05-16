using Eedi.Business.Entities;

namespace Eedi.Business.Contract
{
    public interface IImproveService
    {
        Task<Improve?> GetImproveAsync(string userName);       
        Task<MisconceptionAnswer> UpdateMisconceptionAnswerAsync(MisconceptionAnswer misconceptionAnswer);
    }
}
