using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Core.Entities
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string Concept { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string NoTransaction { get; set; }
        public string Type { get; set; }
        public int? IdAccount { get; set; }
        public int? IdOrigin { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
        public virtual Origin IdOriginNavigation { get; set; }
    }
}
