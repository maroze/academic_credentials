﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebParking.Data.Entities;
using WebParking.Data.Repositories;
using WebParking.Service.Models;

namespace WebParking.Service.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private string mysecret;
        private string myexpDate;

        private readonly IUserRepository _userRepository;
        
        public TokenService(IConfiguration config, IUserRepository userRepository)
        {
            mysecret = config.GetSection("JwtConfig").GetSection("secret").Value;
            myexpDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
            _userRepository = userRepository;
        }

        public async Task<string> GenerateSecurityTokenAsync(UserEntityModel user)
        {
            var result = await _userRepository.GetById(user.UserId);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(mysecret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Email, result.Email),
                new Claim(ClaimTypes.Role,  result.Role.Name),
            }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(myexpDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature), 
                Audience = "localhost",
                Issuer= "localhost"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

