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
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet("credit-account/{id}/[controller]")]
        public async Task<IActionResult> GetPaymentsByCredAccountId(int id)
        {
            IEnumerable<Payment> payments;
            try
            {
                payments = await _paymentService.GetPaymentsByCreditAccountId(id);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            var paymentsDto = _mapper.Map<IEnumerable<PaymentDTO>>(payments);
            var response = new ApiResponse<IEnumerable<PaymentDTO>>(paymentsDto);

            return Ok(response);

        }
    }
}
