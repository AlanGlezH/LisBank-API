using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Core.Interfaces.Services;

namespace LisBank.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> GetClient(int idAuthentication)
        {
            var client = await _clientRepository.GetClient(idAuthentication);
            return client;
        }

        public async Task<IEnumerable<Client>> GetClientsBySearchString(string searchString)
        {
            var client = await _clientRepository.GetClientsBySearchString(searchString);

            return client;
        }
    }
}
