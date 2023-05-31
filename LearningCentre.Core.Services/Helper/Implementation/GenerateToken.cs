using LearningCentre.Core.Services.Helper.Interface;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LearningCentre.Core.Services.Helper.Implementation
{
    public class GenerateToken :IGenerateToken
    {
        private readonly IConfiguration _config;
        private readonly IUserMapping userMapping;
        public GenerateToken(IConfiguration config,IUserMapping userMapping)
        {
            this.userMapping = userMapping;

            _config = config;
        }
        public async Task<string> TokenGenerate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AppSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var FullName = user.FirstName + " " + user.LastName;
            var claims = new[]
            {
                //new Claim(ClaimTypes.NameIdentifier,trainee.Email),
                new Claim(ClaimTypes.Name, FullName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role , await userMapping.GetRole(user.Id))

            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: credentials);


            string str=  "bearer"+" "+ new JwtSecurityTokenHandler().WriteToken(token);
            return str; 

        }

         

    }
}