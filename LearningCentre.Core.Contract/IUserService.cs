using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Contract
{
    public interface IUserService
    {
        //Task<List<UserResponseMOdel>> GetUserAsync();
        Task<PagedList<UserResponseMOdel>> GetUserAsync(int page = 1, int pageSize = 25);

        Task<UserResponseMOdel> GetUserByIdAsync(int Id);

        Task<UserResponseMOdel> AddUserAsync(UserRequestModel userRequestModel);

        Task<int> UpdateUserAsync(int Id, UserUpdateReqModel userUpdateReqModel);

        Task<int> DeleteUserAsync(int Id, UserDeleteRequestModel UserDeleteRequestModel);

        Task<string> UserLogin(UserLoginReqModel userLoginReqModel);

        Task<TranieeViewAssignTaskResponseDTO> GetAssignTaskAsync(int Id);
    }
}