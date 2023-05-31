using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Contract
{
    public interface ITaskEvaluationServices
    {
        Task<string> AddTaskEvaluationAsync(TaskEvaluationRequestModel taskEvaluationRequestModel);

        //Task<List<TaskEvaluationResponseModel>> GetTaskEvaluationAsync();
        Task<PagedList<TaskEvaluationResponseModel>> GetTaskEvaluationAsync(int page = 1, int pageSize = 25);

        Task<TaskEvaluationResponseModel> GetTaskEvaluationByIdAsync(int Id);

        Task<string> DeleteTaskEvaluationAsync(int Id, TaskEvaluationRequestModel taskEvaluationRequestModel);

        Task<string> UpdateTaskEvaluationAsync(int Id, TaskEvaluationRequestModel taskEvaluationRequestModel);
    }
}