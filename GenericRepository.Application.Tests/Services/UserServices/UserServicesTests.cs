using GenericRepository.API.Controllers;
using GenericRepository.Application.Abstractions;
using GenericRepository.Application.Abstractions.IServices;
using GenericRepository.Domain.Entites.DTOs;
using GenericRepository.Domain.Entites.Models;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Application.Tests.Services.UserServices
{
    public class UserServicesTests
    {
        private readonly Mock<IUserService> _userservice;
        public UserServicesTests()
        {
            _userservice = new Mock<IUserService>();
        }

        [Fact]
        public async void Create_User_Test()
        {
            //arrange
            var serviceMock = new Mock<IUserService>();
            var newUser = new UserDTO()
            {

                //bervoradiganimiz
                Name = "Maqsud",
                Email = "maqud@gmail.com",
                Login = "123",
                Password = "123",
                Role = "Admin"
            };
            //kutadiganim
            var expectedUser = new User()
            {
                Name = newUser.Name,
                Email = newUser.Email,
                Login = newUser.Login,
                Password = newUser.Password,
                Role = newUser.Role
            };


            //logic
            _userservice.Setup(x => x.Create(It.IsAny<UserDTO>()))
                .ReturnsAsync(expectedUser);

            var controller = new UsersController(_userservice.Object);

            //act
            var createdUser = await controller.CreateUser(newUser);

            //assert
            Assert.NotNull(createdUser);
            Assert.Equal(createdUser, expectedUser);
        }
    }
}
