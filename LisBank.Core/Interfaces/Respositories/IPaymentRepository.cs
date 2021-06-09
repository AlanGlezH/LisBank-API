using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Respositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsByCreditAccountId(int idCrediAccount);
    }
}
