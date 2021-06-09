using System;
namespace LisBank.Core.DTOs
{
    public class PaymentDTO
    {
        public PaymentDTO()
        {
        }

        public int Id { get; set; }
        public double TotalDebt { get; set; }
        public DateTime PaymentDate { get; set; }
        public double MonthlyTotal { get; set; }
        public double Minimum { get; set; }
        public double PaymentMade { get; set; }
        public DateTime Cycle { get; set; }
        public double Recharge { get; set; }
        public int IdCreditAccount { get; set; }
    }
}
