using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Core.Interfaces.Services;

namespace LisBank.Core.Services
{
    public class DebitAccountService : IDebitAccountService
    {
        private readonly IDebitAccountRepository _debitAccountRepository;

        public DebitAccountService(IDebitAccountRepository debitAccountRepository)
        {
            _debitAccountRepository = debitAccountRepository;
        }

        public async Task<IEnumerable<DebitAccount>> GetDebitAccounts(int idClient)
        {
            var debitAccounts = await _debitAccountRepository.GetDebitAccounts(idClient);
            return debitAccounts;
        }

        public async Task<DebitAccount> InsertDebitAccount(Account account, Client client, string password)
        {
            Authentication authentication = new()
            {
                Username = client.Email,
                Password = password
            };

            var createdDebitAccount = await _debitAccountRepository.InsertDebitAccount(authentication, account, client);

            return createdDebitAccount;
        }
    }
}
