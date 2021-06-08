using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Services
{
    public interface IClientService
    {
        Task<Client> GetClient(int idAuthentication);
        Task<IEnumerable<Client>> GetClientsBySearchString(string searchString);
    }
}
