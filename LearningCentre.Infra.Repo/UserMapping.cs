using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Repo
{
    public class UserMapping : IUserMapping
    {
        private readonly LearningCentreContext _context;
        public UserMapping(LearningCentreContext context) {
         _context= context;
        }
        public async Task<string> GetRole(int userId)
        {
          var role =  _context.UserRoleMappings.FirstOrDefault(x => x.UserId == userId).RoleId;
            var RoleName = _context.Roles.FirstOrDefault(x => x.Id == role).Name;

            return RoleName; 
        }
    }
}
