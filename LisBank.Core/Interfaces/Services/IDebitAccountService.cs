using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Services
{
    public interface IDebitAccountService
    {
        Task<IEnumerable<DebitAccount>> GetDebitAccounts(int idClient);
    }
}
