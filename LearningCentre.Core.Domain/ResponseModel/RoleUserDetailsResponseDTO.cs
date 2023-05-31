using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.ResponseModel
{
    public class RoleUserDetailsResponseDTO
    {
         
         public int UserId { get; set; }
        public string Name { get; set; }
 
        public string Email { get; set; }
    }
}
