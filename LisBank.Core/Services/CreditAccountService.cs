using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Core.Interfaces.Services;

namespace LisBank.Core.Services
{
    public class CreditAccountService : ICreditAccountService
    {
        private readonly ICreditAccountRepository _creditAccountRepository;

        public CreditAccountService(ICreditAccountRepository creditAccounRepository)
        {
            _creditAccountRepository = creditAccounRepository;
        }

        public async Task<IEnumerable<CreditAccount>> GetCreditAccounts(int idClient)
        {
            var creditAccounts = await _creditAccountRepository.GetCreditAccounts(idClient);

            return creditAccounts;
        }
    }
}
