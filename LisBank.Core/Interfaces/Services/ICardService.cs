using System;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Services
{
    public interface ICardService
    {
        Task<Card> GetCardByAccountId(int idAccount);
    }
}
