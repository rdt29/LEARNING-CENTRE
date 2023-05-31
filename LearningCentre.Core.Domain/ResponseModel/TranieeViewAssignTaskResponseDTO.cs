using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.ResponseModel
{
    public class TranieeViewAssignTaskResponseDTO
    {
        public string UserName { get; set; }
        //  public string Status { get; set; }

        public IEnumerable<TranieeViewTaskDetailsResponseDTO> Details { get; set; }
    }
}