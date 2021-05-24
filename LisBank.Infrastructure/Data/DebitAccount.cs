using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Infrastructure.Data
{
    public partial class DebitAccount
    {
        public int Id { get; set; }
        public int IdAccount { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
    }
}
