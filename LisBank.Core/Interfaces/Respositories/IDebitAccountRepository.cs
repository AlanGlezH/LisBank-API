using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Respositories
{
    public interface IDebitAccountRepository
    {
        Task<IEnumerable<DebitAccount>> GetDebitAccounts(int idClient);
    }
}
