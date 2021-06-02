using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<IEnumerable<Authentication>> GetAuthentications();
        Task<Authentication> Login(UserLogin login);
        Task<Authentication> RegisterUser(Authentication authentication);
    }
}
