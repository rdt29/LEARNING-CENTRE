using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain;
using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Repo
{
    public class AssignTaskRespository : IAssignTaskRepository
    {
        private readonly LearningCentreContext _context;

        public AssignTaskRespository(LearningCentreContext context)
        {
            _context = context;
        }

        public async Task<int> AddAssignTask(AssignTask assignTask)
        {
            var task = _context.AssignTasks.GroupBy(x => x.UserId == assignTask.UserId);
            if (task.ToList().Count ==0)
            {
                _context.AssignTasks.AddAsync(assignTask);
                return await _context.SaveChangesAsync();
            }
            foreach (var group in task)
            {
                var count = 0;
                foreach (var item in group)
                {
                    if (item.TaskId == assignTask.TaskId)
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    _context.AssignTasks.AddAsync(assignTask);
                    return await _context.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }

        //public async Task<List<AssignTask>> GetAssignTask()
        //{
        //    var t = await _context.AssignTasks.ToListAsync();
        //    return t;

        //}
        public async Task<PagedList<AssignTask>> GetAssignTask(int page = 1, int pageSize = 25)
        {
            try
            {
                var assignTask = _context.AssignTasks.AsQueryable();
                var count = await assignTask.LongCountAsync();
                var pagedList = assignTask.ToPagedList(page, pageSize, count);
                return pagedList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<AssignTask>> GetAssignTaskById(int Id)
        {
            var assignTask = await _context.AssignTasks.Where(x => x.UserId == Id).ToListAsync();
            return assignTask;
        }

        public async Task<int> UpdateAssignTask(AssignTask assignTask)
        {
            _context.AssignTasks.Update(assignTask);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAssignTask(int UserId, int TaskId)
        {
            _context.AssignTasks.Remove(_context.AssignTasks.FirstOrDefault(x => x.UserId == UserId && x.TaskId == TaskId));
            return await _context.SaveChangesAsync();
        }
    }
}