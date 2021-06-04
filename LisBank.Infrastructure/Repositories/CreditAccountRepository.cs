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
    public class CreditAccountRepository : ICreditAccountRepository
    {
        private readonly LisBankContext _context;

        public CreditAccountRepository(LisBankContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreditAccount>> GetCreditAccounts(int idClient)
        {
            var creditAccounts = await _context.CreditAccounts
                .Where(creditAccount => creditAccount.IdAccountNavigation.IdClient == idClient)
                .Include(creditAccount => creditAccount.IdAccountNavigation)
                .ToListAsync();

            return creditAccounts;
        }
    }
}
