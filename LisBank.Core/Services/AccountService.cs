using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Services;

namespace LisBank.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IDebitAccountService _debitAccountService;

        public AccountService(IDebitAccountService debitAccountService)
        {
            _debitAccountService = debitAccountService;
        }

        public Task<IEnumerable<Account>> GetAccounts(int idClient)
        {
            throw new NotImplementedException();
        }
    }
}
