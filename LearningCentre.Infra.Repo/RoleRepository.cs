using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain;
using LearningCentre.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningCentre.Infra.Repo
{
    public class RoleRepository : IRoleRepository
    {
        private readonly LearningCentreContext _context;

        public RoleRepository(LearningCentreContext context)
        {
            _context = context;
        }

        public async Task<int> AddRole(Role role)
        {
            _context.Roles.Add(role);
            return await _context.SaveChangesAsync();
        }

        public async Task<string> AssignTeams(int SuperiorId, int TranieeId)
        {
            try
            {
                var Traniee = _context.Users.Where(x => x.Id == TranieeId).FirstOrDefault();

                if (Traniee == null)
                {
                    throw new NullReferenceException("No Traniee Found! ");
                }

                Traniee.SuperiorId = SuperiorId;
                await _context.SaveChangesAsync();

                return "done";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Role>> GetRole()
        {
            var role = _context.Roles.Include(x => x.UserRoleMapping).ThenInclude(x => x.User).ToList();

            return role;
        }

        public async Task<List<User>> TeamList()
        {
            try
            {
                var team = await _context.Users.Include(x => x.users).ToListAsync();

                if (team == null)
                {
                    throw new NullReferenceException("No Teams Found! ");
                }
                return team;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<PagedList<Role>> GetRole(int page=1,int pageSize=25)
        //{
        //    try
        //    {
        //    //var role = _context.Roles.AsQueryable();
        //     var role =  _context.Roles.Include(x=>x.UserRoleMapping).ThenInclude(x=>x.User).AsQueryable();
        //    var count = await role.LongCountAsync();
        //    var pagedList = role.ToPagedList(page, pageSize,count);
        //    return pagedList;
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}