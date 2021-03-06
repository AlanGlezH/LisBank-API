using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactionsByIdClient(int idClient);
    }
}
