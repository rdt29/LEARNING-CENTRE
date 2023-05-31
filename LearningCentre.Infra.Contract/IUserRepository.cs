using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Contract
{
    public interface IUserRepository
    {
        //Task<List<User>> GetUsers();
        Task<PagedList<User>> GetUsers(int page = 1, int pageSize = 25);

        Task<User> GetUserById(int Id);

        Task<User> AddUser(User user);

        Task<int> UpdateUser(int Id, User user);

        Task<int> DeleteUser(int Id, User user);

        Task<User> UserLogin(string Email);

        Task<User> GetTaskAssign(int id);
    }
}