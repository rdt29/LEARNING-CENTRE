using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.RequestModel
{
    public class UserRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int[] RoleId { get; set; }
        public int[] TechnologyId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}