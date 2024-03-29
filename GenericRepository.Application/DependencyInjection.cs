﻿using GenericRepository.Application.Abstractions;
using GenericRepository.Application.Abstractions.IServices;
using GenericRepository.Application.Mappers;
using GenericRepository.Application.Services.AuthServices;
using GenericRepository.Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}
