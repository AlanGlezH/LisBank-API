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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LisBankContext _context;

        public TransactionRepository(LisBankContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByIdAccount(int idAccount)
        {
            var transactions = await _context.Transactions
                .Where(transaction => transaction.IdAccount == idAccount)
                .Include(transaction => transaction.IdOriginNavigation)
                .ToListAsync();

            return transactions;
        }

    }
}
