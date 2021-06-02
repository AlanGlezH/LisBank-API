using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Services
{
    public interface IClientService
    {


        Task<IEnumerable<Client>> GetClients();
        Task<IEnumerable<Client>> SearchClients(string clientName, string email);
    }
}
