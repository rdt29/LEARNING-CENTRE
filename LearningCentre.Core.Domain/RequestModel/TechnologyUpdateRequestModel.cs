using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.RequestModel
{
    public class TechnologyUpdateRequestModel
    {

        public string Name { get; set; }
        public string? Description { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
