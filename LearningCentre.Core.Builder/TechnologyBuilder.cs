using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Builder
{
    public class TechnologyBuilder
    {
        public static Technology Build(TechnologyRequestModel technologyRequestModel)
        {
            return new Technology(technologyRequestModel.Name, technologyRequestModel.Description);
        }
    }
}
