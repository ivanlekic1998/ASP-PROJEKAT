using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnlineDeliveryProject.Application.Requests.Customers;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Implementation.Validators.Customers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDeliveryProject.Api.Core
{
    public class JwtManager 
    { 

        private readonly OnlineDeliveryContext _context;
        private readonly LoginCustomerValidator _validator;
        public JwtManager(OnlineDeliveryContext context, LoginCustomerValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public string MakeToken(LoginRequest request)
        {

            _validator.ValidateAndThrow(request);

            var user = _context.Customers.Include(u => u.CustomerUseCases)
                .FirstOrDefault(x => x.Email == request.Email);

            if (user == null)
            {
                return null;
            }

            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.CustomerUseCases.Select(x => x.UseCaseId),
                Identity = user.Email
            };

            var issuer = "delivery_api";
            var secretKey = "ThisIsMyVerySecretKey!";
            var claims = new List<Claim> 
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                    new Claim(JwtRegisteredClaimNames.Iss, "blog_api", ClaimValueTypes.String, issuer),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                    new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                    new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(1130),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
}
}
