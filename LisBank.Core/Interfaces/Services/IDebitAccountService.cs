using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Services
{
    public interface IDebitAccountService
    {
        Task<IEnumerable<DebitAccount>> GetDebitAccounts(int idClient);
        Task<DebitAccount> InsertDebitAccount(Account account, Client client, string password);
    }
}
