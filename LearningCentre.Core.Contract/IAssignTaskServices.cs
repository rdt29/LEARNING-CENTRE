using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
namespace LearningCentre.Core.Contract
{
    public interface IAssignTaskServices
    {
        Task AddAssignTaskAsync(AssignTaskRequestModel assignTaskRequestModel , int addedBy);
        // Task<List<AssignTaskResponseModel>> GetAssignTaskAsync();
        Task<PagedList<AssignTaskResponseModel>> GetAssignTaskAsync(int page = 1, int pageSize = 25);
        Task<List<AssignTaskResponseModel>> GetAssignTaskByIdAsync(int Id);
        Task DeleteAssignTaskAsync(int UserId, int TaskId);
        Task UpdateAssignTaskAsync(AssignTaskRequestModel a);
    }
}
