using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = LearningCentre.Infra.Domain.Entities.Task;



namespace LearningCentre.Infra.Contract
{
    public interface ITaskRepository
    {
        //Task<List<Task>> GetTask();
        Task<PagedList<Task>> GetTask(int page = 1, int pageSize = 25);
        Task <Task> GetTaskById(int id);
       Task <Task> AddTask(Task task);
        
    }
}
