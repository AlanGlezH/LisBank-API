using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Core.Interfaces.Services;

namespace LisBank.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<IEnumerable<Authentication>> GetAuthentications()
        {
            var listAuthentications = await _authenticationRepository.GetAuthentications();

            return listAuthentications;
        }

        public async Task<Authentication> Login(UserLogin login)
        {
            var authentication = await _authenticationRepository.GetLoginByCredentials(login);
            return authentication;
        }

        public Task<Authentication> RegisterUser(Authentication authentication)
        {
            throw new System.NotImplementedException();
        }
    }
}
