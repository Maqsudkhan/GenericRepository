using GenericRepository.Domain.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Application.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
