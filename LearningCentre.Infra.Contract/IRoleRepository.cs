using LearningCentre.Infra.Domain.Entities;

namespace LearningCentre.Infra.Contract
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRole();

        //Task<PagedList<Role>> GetRole(int page = 1, int pageSize = 25);
        Task<int> AddRole(Role role);

        Task<List<User>> TeamList();

        Task<string> AssignTeams(int SuperiorId, int TranieeId);
    }
}