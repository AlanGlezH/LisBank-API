using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LisBank.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly LisBankContext _context;

        public PaymentRepository(LisBankContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByCreditAccountId(int idCrediAccount)
        {
            var payments = await _context.Payments
                 .Where(payment => payment.IdCreditAccount == idCrediAccount)
                 .ToListAsync();

            return payments;
        }
    }
}
