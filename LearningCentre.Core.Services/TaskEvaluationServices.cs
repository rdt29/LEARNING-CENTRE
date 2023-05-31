using AutoMapper;
using LearningCentre.Core.Builder;
using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.Exceptions;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Services
{
    public class TaskEvaluationServices : ITaskEvaluationServices
    {
        private readonly ITaskEvaluationRepository _taskEvaluationRepository;
        private readonly IMapper _mapper;

        public TaskEvaluationServices(ITaskEvaluationRepository taskEvaluationRepository, IMapper mapper)
        {
            _taskEvaluationRepository = taskEvaluationRepository;
            _mapper = mapper;
        }

        public async Task<string> AddTaskEvaluationAsync(TaskEvaluationRequestModel taskEvaluationRequestModel)
        {
            try
            {
                //var taskEvaluation = TaskEvaluationBuilder.Build(taskEvaluationRequestModel);
                TaskEvaluation taskEvaluation = new TaskEvaluation()
                {
                    CodingConvention = taskEvaluationRequestModel.CodingConvention,
                    SubmittedTaskId = taskEvaluationRequestModel.SubmittedTaskId,
                    FeedBack = taskEvaluationRequestModel.FeedBack,
                    Discipline = taskEvaluationRequestModel.Discipline,
                    Communication = taskEvaluationRequestModel.Communication,
                    CreatedOn = new DateTimeOffset(),
                    LearningAdaptability = taskEvaluationRequestModel.LearningAdaptability,
                    TechnicalSkill = taskEvaluationRequestModel.TechnicalSkill,
                };
                var res = await _taskEvaluationRepository.AddTaskEvaluation(taskEvaluation);

                return "Marks Uploaded !";
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<List<TaskEvaluationResponseModel>> GetTaskEvaluationAsync()
        //{
        //    try
        //    {
        //        var t = await _taskEvaluationRepository.GetTaskEvaluation();
        //        var result = _mapper.Map<List<TaskEvaluationResponseModel>>(t);
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<PagedList<TaskEvaluationResponseModel>> GetTaskEvaluationAsync(int page = 1, int pageSize = 25)
        {
            try
            {
                var taskEvaluation = await _taskEvaluationRepository.GetTaskEvaluation(page, pageSize);
                var result = _mapper.Map<PagedList<TaskEvaluationResponseModel>>(taskEvaluation);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TaskEvaluationResponseModel> GetTaskEvaluationByIdAsync(int Id)
        {
            try
            {
                var taskEvaluation = await _taskEvaluationRepository.GetTaskEvaluationById(Id);
                var result = _mapper.Map<TaskEvaluationResponseModel>(taskEvaluation);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteTaskEvaluationAsync(int Id, TaskEvaluationRequestModel taskEvaluationRequestModel)
        {
            try
            {
                var taskEvaluation = await _taskEvaluationRepository.GetTaskEvaluationById(Id);
                if (taskEvaluation == null)
                {
                    throw new NotFoundException($"{Id} is not found .");
                }
                taskEvaluation.DeleteTaskEvaluation();
                var count = await _taskEvaluationRepository.DeleteTaskEvaluation(Id, taskEvaluation);
                if (count == 0)
                {
                    throw new BadRequestException(" Task Evaluation is not deleted successfully.");
                }
                return "Deleted";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateTaskEvaluationAsync(int Id, TaskEvaluationRequestModel taskEvaluationRequestModel)
        {
            try
            {
                var taskEvaluation = await _taskEvaluationRepository.GetTaskEvaluationById(Id);
                taskEvaluation.UpdatedOn = DateTimeOffset.Now;
                if (taskEvaluation == null)
                {
                    throw new NotFoundException($"{Id} is not found.");
                }
                taskEvaluation.UpdateTaskEvaluation(taskEvaluationRequestModel.SubmittedTaskId, taskEvaluationRequestModel.CodingConvention, taskEvaluationRequestModel.Discipline
                    , taskEvaluationRequestModel.Communication, taskEvaluationRequestModel.LearningAdaptability, taskEvaluationRequestModel.FeedBack);
                var count = await _taskEvaluationRepository.UpdateTaskEvaluation(Id, taskEvaluation);
                if (count == 0)
                {
                    throw new BadRequestException("Task Evaluation is not updated successfully.");
                }
                return "updated!!";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}