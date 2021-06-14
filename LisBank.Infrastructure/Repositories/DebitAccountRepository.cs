using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Infrastructure.Data;
using LisBank.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LisBank.Infrastructure.Repositories
{
    public class DebitAccountRepository : IDebitAccountRepository 
    {
        private readonly LisBankContext _context;
        private readonly IPasswordService _passwordService;

        public DebitAccountRepository(LisBankContext lisBankContext, IPasswordService passwordService )
        {
            _context = lisBankContext;
            _passwordService = passwordService;
        }

        public async Task<IEnumerable<DebitAccount>> GetDebitAccounts(int idClient)
        {
            var debitAccounts = await _context.DebitAccounts
                .Where(debitAccount => debitAccount.IdAccountNavigation.IdClient == idClient)
                .Include(account => account.IdAccountNavigation)
                .ToListAsync();

            return debitAccounts;
        }

        public async Task<DebitAccount> InsertDebitAccount(Authentication authentication, Account account, Client client)
        {
            authentication.Password = _passwordService.Hash(authentication.Password);
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                _context.Authentications.Add(authentication);
                await _context.SaveChangesAsync();
                client.IdAuthentication = authentication.Id;
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                account.IdClient = client.Id;
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                var debitAccount = new DebitAccount
                {
                    IdAccount = account.Id
                };
                _context.DebitAccounts.Add(debitAccount);
                await _context.SaveChangesAsync();

                transaction.Commit();

                return debitAccount;
            }
        }
    }
}
