using GenericRepository.Domain.Entites.DTOs;
using GenericRepository.Domain.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Application.Abstractions.IServices
{
    public interface IAuthService
    {
        public Task<ResponseLogin> GenerateToken(RequestLogin user);
    }
}
