using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Core.Entities
{
    public partial class OriginBranchOffice
    {
        public int IdOriginBranchOffice { get; set; }
        public int IdOrigin { get; set; }
        public int IdBranchOffice { get; set; }

        public virtual BranchOffice IdOriginBranchOfficeNavigation { get; set; }
        public virtual Origin IdOriginNavigation { get; set; }
    }
}
