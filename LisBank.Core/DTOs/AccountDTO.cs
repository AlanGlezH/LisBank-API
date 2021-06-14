using System;
namespace LisBank.Core.DTOs
{
    public class AccountDTO
    {
        public AccountDTO()
        {
        }

        public int Id { get; set; }
        public string Clabe { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Number { get; set; }
        public double AvailableBalance { get; set; }
        public int IdClient { get; set; }
        public CardDTO Card { get; set; }
    }
}
