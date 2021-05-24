using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LisBank.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly LisBankContext _context;

        public ClientRepository(LisBankContext lisBankContext)
        {
            _context = lisBankContext;
        }

        public async Task<IEnumerable<Core.Entities.Client>> GetClients()
        {
            //var client1 = new Client { Id = 1, Name = "Alan González" };
            //var client2 = new Client { Id = 1, Name = "Alan González" };

            //var listClients = new List<Client>
            //{
            //    client1,
            //    client2
            //};
            try
            {
                var listClients = new List<Core.Entities.Client>();
                var logins = await _context.Authentications.ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            

            return null;
        }
    }
}
