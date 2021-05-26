using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Core.Entities
{
    public partial class BranchOffice
    {
        public BranchOffice()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int NoBranchOffice { get; set; }

        public virtual Origin IdNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
