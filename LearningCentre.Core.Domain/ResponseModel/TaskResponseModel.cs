using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.ResponseModel
{
    public class TaskResponseModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string?  DocumentURL { get; set; }
    }
}
