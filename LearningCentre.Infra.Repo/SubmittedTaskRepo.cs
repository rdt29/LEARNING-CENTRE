using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain;
using LearningCentre.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Repo
{
    public class SubmittedTaskRepo : ISubmittedTaskRepository
    {
        private readonly LearningCentreContext _context;
        public SubmittedTaskRepo(LearningCentreContext context )
        {
            _context = context;
                
        }

        public async Task<SubmittedTasks> AddTask(SubmittedTasks submittedTasks)
        {
            try
            {
                _context.SubmittedTasks.Add(submittedTasks);
                await _context.SaveChangesAsync();
                return submittedTasks;
            }
            catch (Exception)
            {
                throw;
            }
        }

       

        public async Task<List<SubmittedTasks>> GetSubmittedTask()
        {
            var submittedTask= await  _context.SubmittedTasks.ToListAsync();
             return submittedTask;
        }

        public async Task<SubmittedTasks> GetSubmittedTaskById(int Id)
        {

            var submittedTask = _context.SubmittedTasks.FirstOrDefault(x => x.Id == Id);
            return submittedTask;
        }

        public async Task<int> UpdateSubmittedTask(int Id,SubmittedTasks submittedTask)
        {
            _context.SubmittedTasks.Update(submittedTask);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteSubmittedTask(int Id,SubmittedTasks submittedTask)
        {
            _context.SubmittedTasks.Remove(submittedTask); 
            return await _context.SaveChangesAsync();
        }
    }
}
