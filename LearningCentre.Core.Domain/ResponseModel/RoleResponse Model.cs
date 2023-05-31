using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.ResponseModel
{
    public class RoleResponseMOdel

    {
        

        public IEnumerable<RoleUserMappingResponseDTO> RoleMaping { get; set; }
    }
}
