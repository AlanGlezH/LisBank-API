using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Core.Entities
{
    public partial class Client
    {
        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string ProofIncome { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Ine { get; set; }
        public string NoClient { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int IdAuthentication { get; set; }

        public virtual Authentication IdAuthenticationNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
