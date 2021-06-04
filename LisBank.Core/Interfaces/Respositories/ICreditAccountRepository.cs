using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Respositories
{
    public interface ICreditAccountRepository
    {
        Task<IEnumerable<CreditAccount>> GetCreditAccounts(int idClient);
    }
}
