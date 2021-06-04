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
    public class ClientRepository : IClientRepository
    {
        private readonly LisBankContext _lisBankContext;

        public ClientRepository(LisBankContext lisBankContext)
        {
            _lisBankContext = lisBankContext;
        }

        public async Task<Client> GetClient(int idAuthentication)
        {
            var client = await _lisBankContext.Clients.Where(client => client.IdAuthentication == idAuthentication).FirstOrDefaultAsync();

            return client;
        }
    }
}
