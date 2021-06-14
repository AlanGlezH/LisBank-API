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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LisBank.API.Controllers
{
    [Route("[controller]")]
    public class DebitAccountsController : Controller
    {
        private readonly IDebitAccountService _debitAccountService;
        private readonly IMapper _mapper;

        public DebitAccountsController(IDebitAccountService debitAccountService, IMapper mapper)
        {
            _debitAccountService = debitAccountService;
            _mapper = mapper;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> InsertCreditAccount(InsertDebitAccountDTO insertDebitAccountDto)
        {
            var account = _mapper.Map<Account>(insertDebitAccountDto);
            var client = _mapper.Map<Client>(insertDebitAccountDto);
            DebitAccount debitAccount;
            try
            {
                debitAccount = await _debitAccountService.InsertDebitAccount(account, client, insertDebitAccountDto.Password);
            }catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            var debitAccountDto = _mapper.Map<DebitAccountDTO>(debitAccount);
            var response = new ApiResponse<DebitAccountDTO>(debitAccountDto);

            return Ok(response);
        }

      
    }
}
