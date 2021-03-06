using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetPaymentsByCreditAccountId(int idCreditAccount);
    }
}
