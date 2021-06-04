using System;
using System.Collections.Generic;
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
    public class AccountsController : Controller
    {
        private readonly IDebitAccountService _debitAccountService;
        private readonly ICreditAccountService _creditAccountService;
        private readonly IMapper _mapper;

        public AccountsController(IDebitAccountService debitAccountService, ICreditAccountService creditAccountService, IMapper mapper)
        {
            _debitAccountService = debitAccountService;
            _creditAccountService = creditAccountService;
            _mapper = mapper;
        }

        [HttpGet("clients/{id}/[controller]")]
        public async Task<IActionResult> GetAccounts(int idClient)
        {
            IEnumerable<DebitAccount> debitAccounts;
            IEnumerable<CreditAccount> creditAccounts;
            try
            {
                debitAccounts = await _debitAccountService.GetDebitAccounts(idClient);
                creditAccounts = await _creditAccountService.GetCreditAccounts(idClient);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            var accountsDto = _mapper.Map<IEnumerable<DebitAccountDTO>>(debitAccounts);
            var creditAccountsDto = _mapper.Map<IEnumerable<CreditAccountDTO>>(creditAccounts);
            var response = new ApiResponse<dynamic>(new
            {
                DebitAccounts = accountsDto,
                CreditAccounts = creditAccountsDto
            });

            return Ok(response);
        }
    }
}
