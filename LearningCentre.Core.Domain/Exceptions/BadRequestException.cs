using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.Exceptions
{
    public class BadRequestException:IOException
    {
        public BadRequestException(string message) : base(message) { }
    }

}
