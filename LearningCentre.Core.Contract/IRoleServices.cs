using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = LearningCentre.Infra.Domain.Entities.Task;

namespace LearningCentre.Core.Contract
{
    public interface IRoleServices
    {
        Task<RoleResponseMOdel> GetRoleAsync();

        //Task<PagedList<RoleResponseMOdel>> GetRoleAsync(int page = 1, int pageSize = 25);

        Task<Role> AddRoleAsync(RoleRequestModel roleRequestModel , int Addedbyid);

        Task<IEnumerable<TeamSuperiorResponseDTO>> Team();

        Task<string> AssignTeamAsync(int SuperiorId, int TranieeId);
    }
}