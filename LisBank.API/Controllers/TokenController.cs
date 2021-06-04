using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LisBank.API.Responses;
using LisBank.Core.DTOs;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Services;
using LisBank.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LisBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPasswordService _passwordService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public TokenController(IAuthenticationService authenticationService, IPasswordService passwordService, IClientService clientService, IMapper mapper, IConfiguration configuration)
        { 
            _authenticationService = authenticationService;
            _passwordService = passwordService;
            _clientService = clientService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var client = await _clientService.GetClient(validation.Item2.Id);
                var clientDto = _mapper.Map<ClientDTO>(client);
                var token = GenerateToken(validation.Item2);
                var response = new ApiResponse<ClientDTO>(clientDto);

                return Ok(new { response, token });
            }

            return NotFound();
        }

        private async Task<(bool, Authentication)> IsValidUser(UserLogin login)
        {
            var authentication = await _authenticationService.Login(login);
            var isValid = authentication is null ?
                false :
                _passwordService.Check(authentication.Password, login.Password);

            return (isValid, authentication);
        }

        private string GenerateToken(Authentication authentication)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, authentication.Username),
            };
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddDays(1)
            );
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
