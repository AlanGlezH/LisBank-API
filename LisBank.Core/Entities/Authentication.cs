using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Core.Entities
{
    public partial class Authentication
    {
        public Authentication()
        {
            Clients = new HashSet<Client>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public string Device { get; set; }
        public string Username { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
