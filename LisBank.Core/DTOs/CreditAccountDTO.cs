using System;
namespace LisBank.Core.DTOs
{
    public class CreditAccountDTO
    {
        public CreditAccountDTO()
        {
        }

        public int Id { get; set; }
        public double Annuity { get; set; }
        public double MaxCredit { get; set; }
        public DateTime ClosingDate { get; set; }
        public DateTime PaymentdueDate { get; set; }
        public double? MonthlyPayment { get; set; }
        public double? MinimumPayment { get; set; }

        public virtual AccountDTO Account { get; set; }
    }
}
