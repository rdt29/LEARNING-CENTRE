using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.ResponseModel
{
    public class RoleUserMappingResponseDTO
    {
        public int roleId { get; set; }

        public string roleName { get; set; }
        public IEnumerable<RoleUserDetailsResponseDTO> RoleUserDetails { get; set; }

    }
}
