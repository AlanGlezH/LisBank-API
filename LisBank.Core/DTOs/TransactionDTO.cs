using System;
namespace LisBank.Core.DTOs
{
    public class TransactionDTO
    {
        public TransactionDTO()
        {
        }

        public int Id { get; set; }
        public string Concept { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string NoTransaction { get; set; }
        public string Type { get; set; }
        public int? IdAccount { get; set; }
        public int? IdOrigin { get; set; }
        public OriginDTO Origin { get; set; }
    }
}
