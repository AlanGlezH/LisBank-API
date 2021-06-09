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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LisBank.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet("client/account/{idAccount}/[controller]")]
        public async Task<IActionResult> GetTransactionsByIdAccount(int idAccount)
        {
            IEnumerable<Transaction> transactions;
            try
            {
                transactions = await _transactionService.GetTransactionsByIdClient(idAccount);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            var transactionsDto = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            var response = new ApiResponse<IEnumerable<TransactionDTO>>(transactionsDto);

            return Ok(response);
            
        }


    }
}
