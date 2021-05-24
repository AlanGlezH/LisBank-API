using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Infrastructure.Data
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string Schedule { get; set; }
        public string Name { get; set; }
        public string Responsibility { get; set; }
        public double? Salary { get; set; }

        public virtual Employee IdNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
