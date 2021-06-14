using System;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Respositories
{
    public interface ICardRepository
    {
        Task<Card> GetCardByAccountId(int idAccount);
    }
}
