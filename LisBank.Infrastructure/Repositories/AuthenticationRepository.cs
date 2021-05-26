using System;
using System.Collections.Generic;
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
    }
}
