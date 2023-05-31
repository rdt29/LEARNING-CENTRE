using AutoMapper;
using LEARNING_CENTRE_PROJECT.Configuration;
using LearningCentre.Core.Domain.Exceptions;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Services;
using LearningCentre.Core.Services.Helper.Interface;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.OData.Formatter.Wrapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace ServiceTests
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly MapperConfiguration configuration;
        private readonly IMapper mapper;
        private readonly UserServices _userService;
        private readonly IGenerateToken generateToken;

        public UserServiceTest()
        {
            this._userRepository = new Mock<IUserRepository>();
            var myProfile = new MappingProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            mapper = new Mapper(configuration);
            //_userService = new UserServices(_userRepository.Object, mapper,generateToken);
        }

        [Fact]
        public async Task GetUserById()
        {
            var user = _userRepository.Setup(x => x.GetUserById(1));
            Assert.NotNull(user);
        }

        [Fact]
        public async Task DeleteUser_Success()
        {
            User user = new User()
            {
            };
            UserDeleteRequestModel model = new UserDeleteRequestModel();
            UserDeleteRequestModel userDeleteRequestModel = new UserDeleteRequestModel();
            _userRepository.Setup(x=>x.GetUserById(user.Id)).ReturnsAsync(user);
            var userr =  _userRepository.Setup(x => x.DeleteUser(user.Id, user)).ReturnsAsync(1);
            Assert.NotNull(userr);
        }

        //[Fact]
        //public async Task DeleteUser_Fail()
        //{
        //    User user = new User();
        //    UserDeleteRequestModel userDeleteRequestModel = new UserDeleteRequestModel();
        //    _userRepository.Setup(x => x.GetUserById(user.Id)).ReturnsAsync(user);
        //    _userRepository.Setup(x => x.DeleteUser(user.Id, user)).ReturnsAsync(0);
        //    await Assert.ThrowsAsync<BadRequestException>(async () => await _userService.DeleteUserAsync(user.Id, userDeleteRequestModel));

       //}
        [Fact]
        public async Task UpdateUser_Fail()
        {
            User user = new User();
            UserUpdateReqModel userUpdateReqModel = new UserUpdateReqModel();
            _userRepository.Setup(x=>x.GetUserById(user.Id)).ReturnsAsync(user);
            _userRepository.Setup(x => x.UpdateUser(user.Id, user)).ReturnsAsync(0);
            Assert.ThrowsAsync<BadRequestException>(async () => await _userService.UpdateUserAsync(user.Id, userUpdateReqModel));


            _userRepository.Setup(repo => repo.GetUserById(user.Id)).ReturnsAsync(user);
            _userRepository.Setup(x => x.DeleteUser(user.Id, user)).ReturnsAsync(1);
            //await _userService.DeleteUserAsync(user.Id, userDeleteRequestModel);
        }


        }
        [Fact]
        public async Task UpdateUser_Pass()
        {
            User user = new User();
            UserUpdateReqModel userUpdateReqModel = new UserUpdateReqModel();
            _userRepository.Setup(x => x.GetUserById(user.Id)).ReturnsAsync(user);
            var userr = _userRepository.Setup(x=>x.UpdateUser(user.Id,user)).ReturnsAsync(1);
            Assert.NotNull(userr);
        }


    }
}