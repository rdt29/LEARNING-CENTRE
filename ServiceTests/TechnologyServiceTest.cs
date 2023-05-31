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
    public class TechnologyServiceTest
    {
        private readonly Mock<ITechnologyRepository> _repository;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper mapper;
        private readonly TechnologyServices _services;

        public TechnologyServiceTest()
        {
            _repository = new Mock<ITechnologyRepository>();
            var myProfile = new MappingProfile();
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            mapper = new Mapper(_mapperConfiguration);
        }

        [Fact]
        public async Task GetTechnologyById()
        {
            var technology = _repository.Setup(x => x.GetTechnologyById(1));
            Assert.NotNull(technology);
        }

        [Fact]
        public async Task AddTechnology_Fail()
        {
            TechnologyRequestModel technology = new TechnologyRequestModel()
            {

            };
            _repository.Setup(a => a.AddTechnology(It.IsAny<Technology>())).ReturnsAsync(0);
            Assert.ThrowsAsync<BadRequestException>(async () => await _services.AddTechnologyAsync(technology));
        }

        [Fact]
        public async Task AddTechnology_Pass()
        {
            TechnologyRequestModel technology = new TechnologyRequestModel()
            {

            };
            var a = _repository.Setup(a => a.AddTechnology(It.IsAny<Technology>())).ReturnsAsync(1);
            Assert.NotNull(a);
        }

        [Fact]
        public async Task DeleteTechnology_Pass()
        {
            Technology technology = new Technology("name", "description")
            {

            };

            TechnologyRequestModel technologyrequestmodel = new TechnologyRequestModel()
            {

            };
            _repository.Setup(repo => repo.GetTechnologyById(technology.Id)).ReturnsAsync(technology);
            var s = _repository.Setup(x => x.DeleteTechnology(technology.Id, technology)).ReturnsAsync(1);
            Assert.NotNull(s);
        }

        [Fact]
        public async Task DeleteTechnology_Fail()
        {
            Technology technology = new Technology("name", "description")
            {

            };
            TechnologyRequestModel technologyRequestModel = new TechnologyRequestModel()
            {

            };
            _repository.Setup(repo => repo.GetTechnologyById(technology.Id)).ReturnsAsync(technology);
            _repository.Setup(x => x.DeleteTechnology(technology.Id, technology)).ReturnsAsync(0);
            Assert.ThrowsAsync<Exception>(async () => await _services.DeleteTechnologyAsync(technology.Id, technologyRequestModel));
        }

        [Fact]
        public async Task Updatechnology_Pass()
        {
            Technology technology = new Technology("name", "description")
            {

            };
            TechnologyUpdateRequestModel requestModel = new TechnologyUpdateRequestModel()
            {

            };
            _repository.Setup(repo => repo.GetTechnologyById(technology.Id)).ReturnsAsync(technology);
            var t = _repository.Setup(x => x.UpdateTechnology(technology.Id, technology)).ReturnsAsync(1);
            Assert.NotNull(t);

        }

        [Fact]
        public async Task Updatetechnology_Fail()
        {
            Technology technology = new Technology("name", "description")
            {

            };
            TechnologyUpdateRequestModel updaterequestModel = new TechnologyUpdateRequestModel()
            {

            };
            _repository.Setup(repo => repo.GetTechnologyById(technology.Id)).ReturnsAsync(technology);
            _repository.Setup(x => x.UpdateTechnology(technology.Id, technology)).ReturnsAsync(0);
            Assert.ThrowsAsync<BadRequestException>(async () => await _services.UpdateTechnologyAsync(technology.Id,updaterequestModel));

        }

    }

}
