using GenericRepository.Application.Abstractions;
using GenericRepository.Application.Abstractions.IServices;
using GenericRepository.Domain.Entites.DTOs;
using GenericRepository.Domain.Entites.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<User> CreateUser(UserDTO model)
        {
            var result = await _userService.Create(model);
            return result;
        }

        [HttpPut]
        public async Task<User> UpdateUser(int id, UserDTO model)
        {
            var result = await _userService.Update(id, model);
            return result;
        }

        [HttpGet]
        public async Task<User> UserGetById(int id)
        {
            var result = await _userService.GetById(id);

            return result;
        }

         
    }
}    