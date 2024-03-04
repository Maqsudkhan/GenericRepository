using GenericRepository.Domain.Entites.DTOs;
using GenericRepository.Domain.Entites.Models;
using GenericRepository.Domain.Entites.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Application.Abstractions.IServices
{
    public interface IUserService
    {
        public Task<User> Create(UserDTO userDTO);
        public Task<User> GetById(int id);
        public Task<User> GetByName(string name);
        public Task<User> GetByEmail(string email);
        public Task<IEnumerable<UserViewModel>> GetAll();
        public Task<bool> Delete(Expression<Func<User, bool>> expression);
        public Task<User> Update(int Id, UserDTO userDTO);
    }
}
