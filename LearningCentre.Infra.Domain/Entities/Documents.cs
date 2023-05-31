using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Domain.Entities
{
    public class Documents
    {
        public int Id { get; set; }

        public string url { get; set; }

        public SubmittedTasks SubmittedTasks { get; set; }

    }
}
