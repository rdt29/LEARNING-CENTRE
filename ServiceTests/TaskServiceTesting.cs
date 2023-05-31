using AutoMapper;
using LEARNING_CENTRE_PROJECT.Configuration;
using LearningCentre.Core.Domain.Exceptions;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Services;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain.Entities;
using Moq;
using Task = System.Threading.Tasks.Task;

namespace ServiceTests
{
    public class _TaskServiceTesting
    {
        private readonly Mock<ITaskRepository> _taskRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper mapper;
        private readonly TaskServices _taskServices;

        public _TaskServiceTesting()
        {
            _taskRepository = new Mock<ITaskRepository>();
            var myProfile = new MappingProfile();
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            mapper = new Mapper(_mapperConfiguration);
        }

        [Fact]
        public async Task GetTaskById()
        {
            var task = _taskRepository.Setup(x => x.GetTaskById(1));
            Assert.NotNull(task);
        }

    

        
    }
}




