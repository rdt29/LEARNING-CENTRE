using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Infra.Contract
{
    public interface IUserMapping
    {
        Task<string> GetRole(int userId);
    }
}
