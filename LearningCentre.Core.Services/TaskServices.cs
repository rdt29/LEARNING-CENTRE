using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Core.Services.Helper.Interface;
using LearningCentre.Infra.Contract;
using LearningCentre.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = LearningCentre.Infra.Domain.Entities.Task;


namespace LearningCentre.Core.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private readonly ICloudnary cloudnary;
        public TaskServices(ITaskRepository taskRepository, IMapper mapper,IConfiguration configuration,ICloudnary cloudnary)
        {
            this.cloudnary= cloudnary;
            this.configuration=  configuration;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<string> AddTaskAsync(TaskRequestModelAdd taskRequestModelAdd)
        {

            //task.DocumentURL = getURL(taskRequestModelAdd.files);
           
                var task = _mapper.Map<Task>(taskRequestModelAdd);
                task.CreatedOn = DateTime.Now;
                task.DocumentURL = cloudnary.getURL(taskRequestModelAdd.files, "TaskDatabase");
                await _taskRepository.AddTask(task);
           


            //var taskRes = _mapper.Map<TaskResponseModel>(task);

            return "Okay";

        }


        //public async Task<List<TaskResponseModel>> GetTaskAsync()
        //{
        //    try
        //    {
        //        var task = await _taskRepository.GetTask();
        //        var result = _mapper.Map<List<TaskResponseModel>>(task);
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<PagedList<TaskResponseModel>> GetTaskAsync(int page = 1, int pageSize = 25)
        {

            try
            {
                var task =await _taskRepository.GetTask(page, pageSize);
                var result = _mapper.Map<PagedList<TaskResponseModel>>(task);
                return result;
            }
            catch (Exception)
            { 
           
                throw;
            }
        }

        public async Task<TaskResponseModel> GetTaskByIdAsync(int id)
        {
            try
            {
                var task = await _taskRepository.GetTaskById(id);
                var result = _mapper.Map<TaskResponseModel>(task);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}

