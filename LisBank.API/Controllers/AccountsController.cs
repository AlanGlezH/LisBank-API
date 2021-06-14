using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using LisBank.API.Responses;
using LisBank.Core.DTOs;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LisBank.API.Controllers
{
    [ApiController]
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly IDebitAccountService _debitAccountService;
        private readonly ICreditAccountService _creditAccountService;
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public AccountsController(IDebitAccountService debitAccountService,
            ICreditAccountService creditAccountService, IMapper mapper,
            ICardService cardService)
        {
            _debitAccountService = debitAccountService;
            _creditAccountService = creditAccountService;
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpGet("clients/{id}/[controller]")]
        public async Task<IActionResult> GetAccountsByUserId(int idClient)
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

        [HttpGet("client/[controller]")]
        public async Task<IActionResult> GetAccounts()
        {
            var id = User.FindFirstValue("id");
            _ = int.TryParse(id, out int idClient);
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
            var debitAccountsDto = _mapper.Map<IEnumerable<DebitAccountDTO>>(debitAccounts);
            var creditAccountsDto = _mapper.Map<IEnumerable<CreditAccountDTO>>(creditAccounts);
            await GetCards(debitAccountsDto);
            await GetCards(creditAccountsDto);
            var response = new ApiResponse<dynamic>(new
            {
                DebitAccounts = debitAccountsDto,
                CreditAccounts = creditAccountsDto
            });

            return Ok(response);
        }

        private async Task<CardDTO> GetCard(int id)
        {
            var card = await _cardService.GetCardByAccountId(id);
            var carDto = _mapper.Map<CardDTO>(card);
            return carDto;
        }

        private async Task GetCards(dynamic listAccounts)
        {
            foreach (dynamic account in listAccounts)
            {
                account.Account.Card = await GetCard(account.Account.Id);
            }
        }
    }
}
