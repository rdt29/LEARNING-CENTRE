using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = LearningCentre.Infra.Domain.Entities.Task;


namespace LearningCentre.Core.Contract
{
    public interface ITaskServices
    {
        // Task<List<TaskResponseModel>> GetTaskAsync ();
        Task<PagedList<TaskResponseModel>> GetTaskAsync(int page = 1, int pageSize = 25);
        Task <TaskResponseModel> GetTaskByIdAsync (int id);
        Task <string> AddTaskAsync(TaskRequestModelAdd task );
    }
}
