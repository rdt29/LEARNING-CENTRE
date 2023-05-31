using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Contract
{
    public interface ITaskEvaluationRepository
    {
        Task<TaskEvaluation> AddTaskEvaluation(TaskEvaluation taskEvaluation);

        //Task<List<TaskEvaluation>> GetTaskEvaluation();
        Task<PagedList<TaskEvaluation>> GetTaskEvaluation(int page = 1, int pageSize = 25);

        Task<TaskEvaluation> GetTaskEvaluationById(int Id);

        Task<int> UpdateTaskEvaluation(int Id, TaskEvaluation taskEvaluation);

        Task<int> DeleteTaskEvaluation(int Id, TaskEvaluation taskEvaluation);
    }
}