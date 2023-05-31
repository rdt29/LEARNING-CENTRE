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
    public class UserRepository : IUserRepository

    {
        private readonly LearningCentreContext _context;

        public UserRepository(LearningCentreContext context)
        {
            _context = context;
        }

        //public async Task<List<User>> GetUsers()
        //{
        //    var users = await _context.Users.ToListAsync();
        //    return users;
        //}
        public async Task<PagedList<User>> GetUsers(int page = 1, int pageSize = 25)
        {
            try
            {
                var user = _context.Users.AsQueryable();
                var count = await user.LongCountAsync();
                var pagedList = user.ToPagedList(page, pageSize, count);
                return pagedList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetUserById(int Id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == Id);
            return user;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var id = user.Id;
            return user;
        }

        public async Task<int> UpdateUser(int Id, User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteUser(int Id, User user)
        {
            _context.Users.Remove(user);
            return await (_context.SaveChangesAsync());
        }

        public async Task<User> UserLogin(string Email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Email);
            
            return user;
        }

        public async Task<User> GetTaskAssign(int id)
        {
            try
            {
                var Task = await _context
                    .Users.Where(x => x.Id == id)
                    .Include(x => x.AssignTasks)
                    .ThenInclude(x => x.Task)
                    .Include(x => x.AssignTasks)
                    .ThenInclude(x => x.SubmittedTasks)
                    .FirstOrDefaultAsync();

                return Task;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}