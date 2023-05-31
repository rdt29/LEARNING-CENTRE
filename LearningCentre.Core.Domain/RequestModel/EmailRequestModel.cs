using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Domain.RequestModel
{
    public class EmailRequestModel
   {
        public string To { get; set; } = string.Empty;
      public string Subject { get; set; } = string.Empty;
       public string Body { get; set; } = string.Empty; 
       public IFormFile? Attachments { get; set; }   
    }
}
