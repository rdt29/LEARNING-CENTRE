using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Contract
{
    public interface ISubmittedTaskServices
    {
        Task<List<SubmittedTaskResponseModel>> GetSubmitTaskAsync();

        Task<SubmittedTaskResponseModel> GetSubmittedTaskByIdAsync(int Id);

        Task<SubmittedTaskResponseModel> AddSubmitTaskAsync(SubmittedTaskRequestModel submittedTaskRequestModel, int AddedById);

        Task<int> UpdateSubmittedTaskAsync(int Id, SubmittedTaskRequestModel submittedTaskRequestModel, int updatedBy);

        Task<int> DeleteSubmittedTaskAsync(int Id, SubmittedTaskRequestModel submittedTaskRequestModel);
    }
}