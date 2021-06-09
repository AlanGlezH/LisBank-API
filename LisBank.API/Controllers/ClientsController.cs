using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LisBank.API.Responses;
using LisBank.Core.DTOs;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LisBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet("search/{searchString}")]
        public async Task<IActionResult> GetClientsBySearch(string searchString)
        {
            IEnumerable<Client> clients;
            try
            {
                clients = await _clientService.GetClientsBySearchString(searchString);

            }catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            var clientsDto = _mapper.Map<IEnumerable<ClientDTO>>(clients);
            var response = new ApiResponse<IEnumerable<ClientDTO>>(clientsDto);

            return Ok(response);
        }

    }
}
