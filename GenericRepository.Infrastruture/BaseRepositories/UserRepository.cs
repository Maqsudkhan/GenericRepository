using GenericRepository.Application.Abstractions;
using GenericRepository.Domain.Entites.DTOs.Persistance;
using GenericRepository.Domain.Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Infrastruture.BaseRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GenericRepositoryDbContext dbContext) : base(dbContext)
        {

        }

    }
}
