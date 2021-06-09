using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Core.Interfaces.Services;

namespace LisBank.Core.Services
{
    public class PaymentService : IPaymentService 
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByCreditAccountId(int idCreditAccount)
        {
            var payments = await _paymentRepository.GetPaymentsByCreditAccountId(idCreditAccount);

            return payments;
        }
    }
}
