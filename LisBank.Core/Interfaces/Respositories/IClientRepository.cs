using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Respositories
{
    public interface IClientRepository
    {
        Task<Client> GetClient(int idAuthentication);
        Task<IEnumerable<Client>> GetClientsBySearchString(string searchString);
    }
}
