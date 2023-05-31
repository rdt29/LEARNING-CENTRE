using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.RequestModel
{
    public  class UserLoginReqModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
