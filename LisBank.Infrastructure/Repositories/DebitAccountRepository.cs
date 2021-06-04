using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LisBank.Infrastructure.Repositories
{
    public class DebitAccountRepository : IDebitAccountRepository 
    {
        private readonly LisBankContext _context;
        public DebitAccountRepository(LisBankContext lisBankContext)
        {
            _context = lisBankContext;
        }

        public async Task<IEnumerable<DebitAccount>> GetDebitAccounts(int idClient)
        {
            var debitAccounts = await _context.DebitAccounts
                .Where(debitAccount => debitAccount.IdAccountNavigation.IdClient == idClient)
                .Include(account => account.IdAccountNavigation)
                .ToListAsync();

            return debitAccounts;
        }
    }
}
