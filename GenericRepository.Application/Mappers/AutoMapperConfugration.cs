using AutoMapper;
using GenericRepository.Domain.Entites.DTOs;
using GenericRepository.Domain.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Application.Mappers
{
    public class AutoMapperConfugration : Profile
    {
        public AutoMapperConfugration()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
