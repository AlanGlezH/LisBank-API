using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Respositories
{
    public interface IAuthenticationRepository
    {
        Task<IEnumerable<Authentication>> GetAuthentications();
    }
}
