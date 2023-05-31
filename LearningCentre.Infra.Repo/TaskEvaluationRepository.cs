using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain;
using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Repo
{
    public class TaskEvaluationRepository : ITaskEvaluationRepository
    {
        private readonly LearningCentreContext _context;

        public TaskEvaluationRepository(LearningCentreContext context)
        {
            _context = context;
        }

        public async Task<TaskEvaluation> AddTaskEvaluation(TaskEvaluation taskEvaluation)
        {
            _context.TaskEvaluations.Add(taskEvaluation);
            await _context.SaveChangesAsync();
            return taskEvaluation;
        }

        //public async Task<List<TaskEvaluation>> GetTaskEvaluation()
        //{
        //    var t = await _context.TaskEvaluations.ToListAsync();
        //    return t;
        //}
        public async Task<PagedList<TaskEvaluation>> GetTaskEvaluation(int page = 1, int pageSize = 25)
        {
            var taskEvaluation = _context.TaskEvaluations.AsQueryable();
            var count = await taskEvaluation.LongCountAsync();
            var pagedList = taskEvaluation.ToPagedList(page, pageSize, count);
            return pagedList;
        }

        public async Task<TaskEvaluation> GetTaskEvaluationById(int Id)
        {
            var taskEvaluation = await _context.TaskEvaluations.FirstOrDefaultAsync(x => x.Id == Id);
            return taskEvaluation;
        }

        public async Task<int> UpdateTaskEvaluation(int Id, TaskEvaluation taskEvaluation)
        {
            _context.TaskEvaluations.Update(taskEvaluation);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteTaskEvaluation(int Id, TaskEvaluation taskEvaluation)
        {
            _context.TaskEvaluations.Remove(taskEvaluation);
            return await _context.SaveChangesAsync();
        }
    }
}