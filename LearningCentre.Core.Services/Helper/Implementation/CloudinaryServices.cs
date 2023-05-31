using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using LearningCentre.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using LearningCentre.Core.Services.Helper.Interface;
using Microsoft.AspNetCore.Http;

namespace LearningCentre.Core.Services.Helper.Implementation
{
    public class CloudinaryServices :ICloudnary
    {
        private readonly IConfiguration configuration;
        
        public CloudinaryServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string getURL(IFormFile fileUpload,string FolderName)
        {

            //try
            //{
            var file = fileUpload;
            var uploadresult = new ImageUploadResult();
            if (file.Length > 0)
            {
                var obj = configuration.GetSection("Cloudinary");
                var cloudinary = new Cloudinary(new Account(obj.GetSection("CloudName").Value, obj.GetSection("API Key").Value, obj.GetSection("API Secret").Value));
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, stream),
                        PublicId = file.FileName,
                        Folder = FolderName,
                        

                    };

                    var name = fileUpload.Name;

                    uploadresult = cloudinary.Upload(uploadParams);
                    //   _interface1.AddImage(fileUpload.files.FileName, uploadresult.Uri.ToString(), ProductID);
                    var path = uploadresult.SecureUri;
                }

                return uploadresult.Uri.ToString();
            }
            else
            {
                return "failed";
            }
        }
    }
}
