using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Core.Entities
{
    public partial class Origin
    {
        public Origin()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual BranchOffice BranchOffice { get; set; }
        public virtual Device Device { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
