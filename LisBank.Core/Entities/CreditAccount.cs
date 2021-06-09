using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Core.Entities
{
    public partial class CreditAccount
    {
        public CreditAccount()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public double Annuity { get; set; }
        public double MaxCredit { get; set; }
        public DateTime ClosingDate { get; set; }
        public DateTime PaymentdueDate { get; set; }
        public double? MonthlyPayment { get; set; }
        public double? MinimumPayment { get; set; }
        public int IdAccount { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
 