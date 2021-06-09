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
        private readonly IEmployeeService _employeeService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public TokenController(IAuthenticationService authenticationService, IPasswordService passwordService,
            IClientService clientService, IEmployeeService employeeService,
            ITokenService tokenService,IMapper mapper,
            IConfiguration configuration)
        { 
            _authenticationService = authenticationService;
            _passwordService = passwordService;
            _clientService = clientService;
            _employeeService = employeeService;
            _tokenService = tokenService;
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
            var userDto = await GetRelatedUserDto(authentication);
            var accessToken = _tokenService.GenerateAccessToken(DateTime.UtcNow.AddDays(1), authentication.Username, userDto.Id.ToString());
            var refreshToken = _tokenService.GenerateRefreshToken(DateTime.UtcNow.AddDays(3), authentication.Username, userDto.Id.ToString());
            var response = new ApiResponse<dynamic>(userDto);

            return Ok(new { response.Data, accessToken, refreshToken });

        }

        [HttpPost("refresh/{refreshToken}")]
        public IActionResult Refresh(string token)
        {
            try
            {
                var (accessToken, refreshToken) = _tokenService.RefreshToken(token);

                return Ok(new { accessToken, refreshToken });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        private async Task<(bool isValid, Authentication authentication)> IsValidUser(UserLogin login)
        {
            var authentication = await _authenticationService.Login(login);
            var isValid = authentication is not null && _passwordService.Check(authentication.Password, login.Password);

            return (isValid, authentication);
        }

       private async Task<dynamic> GetRelatedUserDto(Authentication authentication)
       {
            var client = await _clientService.GetClient(authentication.Id);
            if (client != null) return _mapper.Map<ClientDTO>(client);

            var employee = await _employeeService.GetEmployeeByIdAuth(authentication.Id);
            if (employee != null) return _mapper.Map<EmployeeDTO>(employee);

            return null;

        }

        private string GenerateToken(string username, DateTime expirationDate, string idUser)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("id", idUser),
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
