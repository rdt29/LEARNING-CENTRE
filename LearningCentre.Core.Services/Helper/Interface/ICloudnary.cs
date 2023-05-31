using LearningCentre.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Services.Helper.Interface
{
    public interface ICloudnary
    {
        public string getURL(IFormFile fileUpload,string FolderName);
    }
}
