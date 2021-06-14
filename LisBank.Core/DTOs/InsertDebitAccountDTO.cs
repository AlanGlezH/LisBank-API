using System;
namespace LisBank.Core.DTOs
{
    public class InsertDebitAccountDTO
    {
        public InsertDebitAccountDTO()
        {
        }

        public string Clabe { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Number { get; set; }
        public double AvailableBalance { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ProofIncome { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Ine { get; set; }
        public string NoClient { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
