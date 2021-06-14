using System;
using System.Linq;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LisBank.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly LisBankContext _lisBankContext;

        public CardRepository(LisBankContext lisBankContext)
        {
            _lisBankContext = lisBankContext;
        }

        public async Task<Card> GetCardByAccountId(int idAccount)
        {
            var card = await _lisBankContext.Cards
                .Where(card => card.IdAccount == idAccount)
                .FirstOrDefaultAsync();

            return card;
        }
    }
}
