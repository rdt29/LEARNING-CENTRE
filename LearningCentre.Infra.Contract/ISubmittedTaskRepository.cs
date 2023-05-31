using LearningCentre.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Contract
{
    public interface ISubmittedTaskRepository
    {
        Task<List<SubmittedTasks>> GetSubmittedTask();
        Task<SubmittedTasks> GetSubmittedTaskById(int Id);
        Task<SubmittedTasks> AddTask(SubmittedTasks submittedTasks);
        Task<int> UpdateSubmittedTask(int Id, SubmittedTasks submittedTask);
        Task<int> DeleteSubmittedTask(int Id, SubmittedTasks submittedTask);


    }
}
