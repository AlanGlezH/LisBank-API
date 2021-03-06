using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LisBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
  
        [HttpGet]
        public async Task<IActionResult> GetAuthentications()
        {
            IEnumerable<Authentication> response;
            try
            {
                response = await _authenticationService.GetAuthentications();
            }catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            
            return Ok(response);
        }
    }
}
