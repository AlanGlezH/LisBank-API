using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Services
{
    public interface ICreditAccountService
    {
        Task<IEnumerable<CreditAccount>> GetCreditAccounts(int idClient);
    }
}
