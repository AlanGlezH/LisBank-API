#nullable disable

namespace LisBank.Core.Entities
{
    public partial class Card
    {
        public int Id { get; set; }
        public string Cvv { get; set; }
        public string DueDate { get; set; }
        public int Nip { get; set; }
        public string Number { get; set; }
        public int IdAccount { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
    }
}
