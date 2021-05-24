using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Infrastructure.Data
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfileImage { get; set; }
        public string NoPersonal { get; set; }
        public string Phone { get; set; }
        public int? IdBranchOffice { get; set; }
        public int IdRole { get; set; }
        public int IdAuthentication { get; set; }

        public virtual Authentication IdAuthenticationNavigation { get; set; }
        public virtual BranchOffice IdBranchOfficeNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
        public virtual Role Role { get; set; }
    }
}
