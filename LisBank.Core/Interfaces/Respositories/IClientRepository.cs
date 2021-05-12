using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Respositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
    }
}
