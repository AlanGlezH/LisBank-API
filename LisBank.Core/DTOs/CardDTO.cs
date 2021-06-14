using System;
namespace LisBank.Core.DTOs
{
    public class CardDTO
    {
        public CardDTO()
        {
        }

        public int Id { get; set; }
        public string Cvv { get; set; }
        public string DueDate { get; set; }
        public int Nip { get; set; }
        public string Number { get; set; }
    }
}
