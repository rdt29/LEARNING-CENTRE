using AutoMapper;
using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.Exceptions;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Core.Services.Helper.Interface;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Services
{
    public class SubmittedTaskServices : ISubmittedTaskServices
    {
        private readonly ISubmittedTaskRepository _submittedTask;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ICloudnary _cloudnary;

        public SubmittedTaskServices(ISubmittedTaskRepository submittedTask, IMapper mapper, IConfiguration configuration, ICloudnary cloudnary)
        {
            _submittedTask = submittedTask;
            _mapper = mapper;
            _configuration = configuration;
            _cloudnary = cloudnary;
        }

        public async Task<SubmittedTaskResponseModel> AddSubmitTaskAsync(SubmittedTaskRequestModel submittedTaskRequestModel, int addedBy)
        {
            {
                var submittask = _mapper.Map<SubmittedTasks>(submittedTaskRequestModel);
                //task.DocumentURL = getURL(taskRequestModelAdd.files);
                submittask.CreatedOn = DateTime.Now;
                submittask.CreatedBy = addedBy;
                submittask.UserId = addedBy;
                if (submittedTaskRequestModel.Files != null)
                {
                    IList<Documents> UrlList = new List<Documents>();

                    foreach (var task in submittedTaskRequestModel.Files)
                    {
                        Documents d = new Documents();

                        d.url = _cloudnary.getURL(task, "SubmitTaskDatabase");
                        UrlList.Add(d);
                    }
                    submittask.Documents = UrlList;
                }

                //submittask.DocumentURL = _cloudnary.getURL(submittedTaskRequestModel.files,"SubmitTaskDatabase");
               var a =  _submittedTask.AddTask(submittask);
                var taskRes = _mapper.Map<SubmittedTaskResponseModel>(a.Result);
                return taskRes;
            }
        }

        public async Task<List<SubmittedTaskResponseModel>> GetSubmitTaskAsync()
        {
            try
            {
                var submittask = await _submittedTask.GetSubmittedTask();
                var result = _mapper.Map<List<SubmittedTaskResponseModel>>(submittask);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SubmittedTaskResponseModel> GetSubmittedTaskByIdAsync(int Id)
        {
            try
            {
                var submittask = await _submittedTask.GetSubmittedTaskById(Id);
                var result = _mapper.Map<SubmittedTaskResponseModel>(submittask);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateSubmittedTaskAsync(int Id, SubmittedTaskRequestModel submittedTaskRequestModel, int updatedby)
        {
            try
            {
                var submitTask = await _submittedTask.GetSubmittedTaskById(Id);
                submitTask.UpdatedOn = DateTimeOffset.Now;
                if (submitTask == null)
                {
                    throw new NotFoundException($"{Id} is not found .");
                }
                submitTask.UpdateSubmitTask(updatedby, submittedTaskRequestModel.Status, submittedTaskRequestModel.Submission,
                    submittedTaskRequestModel.AssignTaskId, submittedTaskRequestModel.Comments, submittedTaskRequestModel.Files);
                var count = await _submittedTask.UpdateSubmittedTask(Id, submitTask);
                if (count == 0)
                {
                    throw new BadRequestException("Submitted Task is not Updated Successfully.");
                }
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteSubmittedTaskAsync(int Id, SubmittedTaskRequestModel submittedTaskRequestModel)
        {
            try
            {
                var submitTask = await _submittedTask.GetSubmittedTaskById(Id);
                if (submitTask == null)
                {
                    throw new NotFoundException($"{Id} is not found.");
                }
                submitTask.DeleteSubmitTask();
                var count = await _submittedTask.DeleteSubmittedTask(Id, submitTask);
                if (count == 0)
                {
                    throw new BadRequestException("Submitted Task is not Deleted Successfully.");
                }
                return (int)count;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}