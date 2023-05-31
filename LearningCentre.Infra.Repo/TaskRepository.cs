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
using Task = LearningCentre.Infra.Domain.Entities.Task;

namespace LearningCentre.Infra.Repo
{
    public class TaskRepository : ITaskRepository
    {
        private readonly LearningCentreContext _context;
        public TaskRepository(LearningCentreContext context)
        {
            _context = context;
        }

        public async Task<Task> AddTask(Task task)
        {
            try
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
                return task;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<List<Task>> GetTask()
        //{
        //    var task = await _context.Tasks.ToListAsync();
        //    return task;
        //}
        public async Task<PagedList<Task>> GetTask(int page=1,int pageSize=25)
        {
            try
            {

            
            var task = _context.Tasks.AsQueryable();
            var count = await task.LongCountAsync();
            var pagedList = task.ToPagedList(page, pageSize, count);
            return pagedList;
            }
            catch(Exception)
            {
                throw;
            }


        }

        public async Task<Task> GetTaskById(int id)
        {
            try
            {
                var task= await _context.Tasks.FirstOrDefaultAsync(x =>x.Id ==id);
                return task;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}



