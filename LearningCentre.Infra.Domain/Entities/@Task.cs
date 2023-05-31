using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Domain.Entities
{
    public class Task : Audit
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string ?TaskDescription { get; set; }
        public string ?DocumentURL { get; set; }
        public ICollection<AssignTask> AssignTask { get; set; }
    }
}