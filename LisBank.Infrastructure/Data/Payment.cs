using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Infrastructure.Data
{
    public partial class Payment
    {
        public int Id { get; set; }
        public double TotalDebt { get; set; }
        public DateTime PaymentDate { get; set; }
        public double MonthlyTotal { get; set; }
        public double Minimum { get; set; }
        public double PaymentMade { get; set; }
        public DateTime Cycle { get; set; }
        public double Recharge { get; set; }
        public int IdCreditAccount { get; set; }

        public virtual CreditAccount IdCreditAccountNavigation { get; set; }
    }
}
