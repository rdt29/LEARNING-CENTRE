using LearningCentre.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Services.Helper.Interface
{
   public interface IGenerateToken
    {
        //Task <string> GenerateToken(User user);
        Task <string> TokenGenerate(User user);
    }
}
