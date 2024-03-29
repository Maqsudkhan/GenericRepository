﻿using GenericRepository.Application.Abstractions.IServices;
using GenericRepository.Domain.Entites.DTOs;
using GenericRepository.Domain.Entites.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _conf;
        private readonly IUserService _userService;

        public AuthService(IConfiguration conf, IUserService userService)
        {
            _conf = conf;
            _userService = userService;
        }

        public async Task<ResponseLogin> GenerateToken(RequestLogin user)
        {
            if (user == null)
            {
                return new ResponseLogin()
                {
                    Token = "User not faound"
                };
            }
            if (await UserExit(user))
            {
                var result = await _userService.GetByLogin(user.Login);
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, result.Role),
                    new Claim("Login", user.Login),
                    new Claim("UserID", result.Id.ToString()),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                };
                return await GenerateToken(claims);
            }
            return new ResponseLogin()
            {
                Token = "Un Authorize"
            };
        }



        public async Task<ResponseLogin> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_conf["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _conf["JWT:ValidIssuer"],
                audience: _conf["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(exDate),
                signingCredentials: credentials);

            return new ResponseLogin()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };


        }


        public async Task<bool> UserExit(RequestLogin user)
        {
            var result = await _userService.GetByLogin(user.Login);
            if (user.Login == result.Login && user.Password == result.Password)
            {
                return true;
            }
            return false;
        } 
    }
}
