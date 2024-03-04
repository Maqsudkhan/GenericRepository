using GenericRepository.Application.Abstractions;
using GenericRepository.Application.Abstractions.IServices;
using GenericRepository.Domain.Entites.DTOs.Persistance;
using GenericRepository.Infrastruture.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Infrastruture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration conf)
        {
            service.AddDbContext<GenericRepositoryDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("DefaultConnection"));
            });
            service.AddScoped<IUserRepository, UserRepository>();
            return service;
        }
    }
}
