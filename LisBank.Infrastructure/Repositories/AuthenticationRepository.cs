using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LisBank.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly LisBankContext _context;

        public AuthenticationRepository(LisBankContext lisBankContext)
        {
            _context = lisBankContext;
        }

        public async Task<IEnumerable<Authentication>> GetAuthentications()
        {
            IEnumerable<Authentication> authentications;         
            authentications = await _context.Authentications.ToListAsync();

            return authentications;
        }

        public async Task<Authentication> GetLoginByCredentials(UserLogin login)
        {
            var authentication = await _context.Authentications.Where(auth => auth.Username == login.User).FirstOrDefaultAsync();
            return authentication;
        }

        public Task<Authentication> InsertAuthentication(Authentication authentication)
        {
            throw new NotImplementedException();
        }
    }
}
