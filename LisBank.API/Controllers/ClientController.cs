using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LisBank.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LisBank.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var response = await _clientService.GetClients();
            
            return Ok(response);
        }
    }
}
