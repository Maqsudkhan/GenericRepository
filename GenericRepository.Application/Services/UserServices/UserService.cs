﻿using GenericRepository.Application.Abstractions;
using GenericRepository.Application.Abstractions.IServices;
using GenericRepository.Domain.Entites.DTOs;
using GenericRepository.Domain.Entites.Models;
using GenericRepository.Domain.Entites.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Application.Services.UserServices
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Create(UserDTO userDTO)
        {
            var user = new User()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Login = userDTO.Login,
                Password = userDTO.Password 
            };
            var result = await _userRepository.Create(user);
            return result;
        }

        public async Task<bool> Delete(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.Delete(expression);
            return result;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var result = await _userRepository.GetAll();
            var rres = result.Select(model => new UserViewModel
            {
                Name = model.Name,
                Email = model.Email,
            });
            return rres;
        }

        public async Task<User> GetByAny(Expression<Func<User, bool>> expression)
        {
            var result  = await _userRepository.GetByAny(expression);
            return result;
        }

        public async Task<User> GetByEmail(string email)
        {
            var res = await _userRepository.GetByAny(x => x.Email == email);
            return res;
        }

        public async Task<User> GetById(int id)
        {
            var res = await _userRepository.GetByAny(x => x.Id == id);
            return res;
        }

        public async Task<User> GetByName(string name)
        {
            var ress = await _userRepository.GetByAny(x => x.Name ==  name);
            return ress;
        }

        public async Task<User> Update(int Id, UserDTO userDTO)
        {
            var res = await _userRepository.GetByAny(x=>x.Id ==Id);

            if (res != null)
            {
                var user = new User()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Login = userDTO.Login,
                    Password = userDTO.Password
                };
                var result = await  _userRepository.Update(user);
                return result;
            }
            return new User();
            
        }
    }
}
    