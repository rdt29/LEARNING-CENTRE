using AutoMapper;
using LEARNING_CENTRE_PROJECT.Configuration;
using LEARNING_CENTRE_PROJECT.FluentValidation;
using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.Exceptions;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Services;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using Org.BouncyCastle.Crypto;
using System.Runtime.CompilerServices;
using Task = System.Threading.Tasks.Task;

namespace ServiceTests
{
    public class TaskEvaluationServiceTest
    {
        private readonly Mock<ITaskEvaluationRepository> _taskEvaluationRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;
        private readonly TaskEvaluationServices _taskEvaluationServices;

        public TaskEvaluationServiceTest()
        {
            this._taskEvaluationRepository = new Mock<ITaskEvaluationRepository>();
            var myProfile = new MappingProfile();
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = new Mapper(_mapperConfiguration);
            _taskEvaluationServices = new TaskEvaluationServices(_taskEvaluationRepository.Object, _mapper);
        }

        [Fact]
        public async Task GetTaskEvaluationById()
        {
            var taskEvaluationList = _taskEvaluationRepository.Setup(x => x.GetTaskEvaluationById(1));
            Assert.NotNull(taskEvaluationList);
        }

        [Fact]
        public async Task DeleteTaskEvaluation_Fail()
        {
            TaskEvaluation taskEvaluation = new TaskEvaluation()
            {

            };
            TaskEvaluationRequestModel taskEvaluationRequestModel = new TaskEvaluationRequestModel();
            _taskEvaluationRepository.Setup(repo=>repo.GetTaskEvaluationById(taskEvaluation.Id)).ReturnsAsync(taskEvaluation);
            _taskEvaluationRepository.Setup(x => x.DeleteTaskEvaluation(taskEvaluation.Id,taskEvaluation)).ReturnsAsync(0);
            await Assert.ThrowsAsync<BadRequestException>(async () => await _taskEvaluationServices.DeleteTaskEvaluationAsync(taskEvaluation.Id,taskEvaluationRequestModel));
        }

        [Fact]
        public async Task DeleteTaskEvaluation_Pass()
        {

            TaskEvaluation taskEvaluation = new TaskEvaluation();
            TaskEvaluationRequestModel taskEvaluationRequestModel = new TaskEvaluationRequestModel();

            _taskEvaluationRepository.Setup(x => x.GetTaskEvaluationById(taskEvaluation.Id)).ReturnsAsync(taskEvaluation);
            var task = _taskEvaluationRepository.Setup(x => x.DeleteTaskEvaluation(taskEvaluation.Id,taskEvaluation)).ReturnsAsync(1);
            Assert.NotEmpty(task.ToString());
        }

        [Fact]
        public async Task UpdateTaskEvaluation_Fail()
        {
            TaskEvaluation taskEvaluation = new TaskEvaluation(); 
            TaskEvaluationRequestModel taskEvaluationRequestModel = new TaskEvaluationRequestModel();
            _taskEvaluationRepository.Setup(x => x.GetTaskEvaluationById(taskEvaluation.Id)).ReturnsAsync(taskEvaluation);
            _taskEvaluationRepository.Setup(x => x.UpdateTaskEvaluation(taskEvaluation.Id, taskEvaluation)).ReturnsAsync(0);
            await Assert.ThrowsAsync<BadRequestException>(async () => await _taskEvaluationServices.UpdateTaskEvaluationAsync(taskEvaluation.Id, taskEvaluationRequestModel));
        }
        [Fact]
        public async Task UpdateTaskEvalution_Pass()
        {
            TaskEvaluation taskEvaluation = new TaskEvaluation();
            TaskEvaluationRequestModel taskEvaluationRequestModel1 = new TaskEvaluationRequestModel();
            _taskEvaluationRepository.Setup(x => x.GetTaskEvaluationById(taskEvaluation.Id)).ReturnsAsync(taskEvaluation);
           // var task = _taskEvaluationRepository.Setup(x=>x.UpdateTaskEvaluation(taskEvaluation.Id,taskEvaluation)).ReturnsAsync(1);
           var task = _taskEvaluationRepository.Setup(x=>x.UpdateTaskEvaluation(It.IsAny<int>(),It.IsAny<TaskEvaluation>())).ReturnsAsync(1);
            Assert.NotEmpty(task.ToString());
           
        }

        
       
    }
}