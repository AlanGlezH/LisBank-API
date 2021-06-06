using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
            var (isValid, authentication) = await IsValidUser(login);
            if (!isValid)
            {
                return NotFound();
            }
            var client = await _clientService.GetClient(authentication.Id);
            var accessToken = GenerateToken(authentication.Username, DateTime.UtcNow.AddDays(1));
            var refreshToken = GenerateToken(authentication.Username, DateTime.UtcNow.AddDays(3));
            var clientDto = _mapper.Map<ClientDTO>(client);
            var response = new ApiResponse<ClientDTO>(clientDto);

            return Ok(new { response, accessToken, refreshToken });

        }

        [HttpPost("refresh/{refreshToken}")]
        public IActionResult Refresh(string refreshToken)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtRefresh = jwtTokenHandler.ReadJwtToken(refreshToken);

            if (DateTime.Now > jwtRefresh.ValidTo)
            {
                return Problem("Token has expirated");
            }
            var username = jwtRefresh.Claims.Where(claim => claim.Type == ClaimTypes.Name).FirstOrDefault();
            var accessToken = GenerateToken(username.Value, DateTime.UtcNow.AddDays(1));
            refreshToken = GenerateToken(username.Value, DateTime.UtcNow.AddDays(3));

            return Ok(new { accessToken, refreshToken });

        }

        private async Task<(bool isValid, Authentication authentication)> IsValidUser(UserLogin login)
        {
            var authentication = await _authenticationService.Login(login);
            var isValid = authentication is not null && _passwordService.Check(authentication.Password, login.Password);

            return (isValid, authentication);
        }

        private string GenerateToken(string username, DateTime expirationDate)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
            };
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                expirationDate
            );
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
