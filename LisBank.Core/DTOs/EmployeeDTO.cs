using System;
namespace LisBank.Core.DTOs
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {
        }

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
        public RoleDTO Role;
    }
}
