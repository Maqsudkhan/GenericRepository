using AutoMapper;
using GenericRepository.API.Controllers;
using GenericRepository.Application.Abstractions;
using GenericRepository.Application.Abstractions.IServices;
using GenericRepository.Application.Mappers;
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
        //1 ta modelni Create qilib test qilish 
        #region
        /*private readonly Mock<IUserService> _userservice;
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
       */
        #endregion


        // Bir nechta moldelni create qilib test qilish

        private readonly Mock<IUserService> _userservice = new Mock<IUserService>();
        MapperConfiguration? mockMapper = new MapperConfiguration(conf =>
        {
            conf.AddProfile(new AutoMapperProfile());
        });

        public static IEnumerable<object[]> GetUserFromDataGenerator()
        {
            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 1",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                },
                new UserDTO()
                {
                    Name = "Test Product 45",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 2",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 2",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 3",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 9897",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 4",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 4",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 5",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 5",
                    Email = "maqsud@gmail.com",
                    Password = "111",
                    Login = "111",
                    Role = "Admin"
                }
            };
        }

        // create user test

        [Theory]
        [MemberData(nameof(GetUserFromDataGenerator), MemberType = typeof(UserServicesTests))]
        public async void Create_User_Tests(UserDTO inputUser,  User expectedUser)
        {
            var myMapper = mockMapper.CreateMapper();

            var result = myMapper.Map<User>(inputUser);

            // logica
            _userservice.Setup(x => x.Create(It.IsAny<UserDTO>()))
                .ReturnsAsync(result);

            var controller = new UsersController(_userservice.Object);

            //act
            var createdUser = await controller.CreateUser(inputUser);

            //assert

            Assert.NotNull(createdUser);
            Assert.True(CompareModels(expectedUser, createdUser));

        }


        public static bool CompareModels(User inputUser, User user)
        {
            if (inputUser.Name == user.Name && inputUser.Email == user.Email && inputUser.Password == user.Password
                && inputUser.Login == user.Login && inputUser.Role == user.Role)
            {
                return true;
            }

            return false;
        }
    }
}



































