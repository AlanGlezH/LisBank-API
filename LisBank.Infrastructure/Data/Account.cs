using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Infrastructure.Data
{
    public partial class Account
    {
        public Account()
        {
            Cards = new HashSet<Card>();
            CreditAccounts = new HashSet<CreditAccount>();
            DebitAccounts = new HashSet<DebitAccount>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Clabe { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Number { get; set; }
        public double AvailableBalance { get; set; }
        public int IdClient { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<CreditAccount> CreditAccounts { get; set; }
        public virtual ICollection<DebitAccount> DebitAccounts { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
