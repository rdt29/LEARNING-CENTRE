using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Contract
{
    public interface IAssignTaskRepository
    {
        Task<int> AddAssignTask(AssignTask assignTask);
        //Task<List<AssignTask>> GetAssignTask();
        Task<PagedList<AssignTask>> GetAssignTask(int page = 1, int pageSize = 25);
        Task<List<AssignTask>> GetAssignTaskById(int Id);
        Task<int> UpdateAssignTask(AssignTask assignTask);
        Task<int> DeleteAssignTask(int UserId,int TaskId);
    }
}
