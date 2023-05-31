using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.ResponseModel
{
    public class TeamSuperiorResponseDTO
    {
        public int? SuperiorId { get; set; }
        public string? SuperiorName { get; set; }
        //public int?  UserId { get; set; }
        //public string? Name { get; set; }
        //public string?  Email { get; set; }

        public IEnumerable<TeamUserResponseDTO>? UsersDetails { get; set; }
    }
}