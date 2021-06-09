using System;
namespace LisBank.Core.DTOs
{
    public class RoleDTO
    {
        public RoleDTO()
        {
        }

        public int Id { get; set; }
        public string Schedule { get; set; }
        public string Name { get; set; }
        public string Responsibility { get; set; }
        public double? Salary { get; set; }
    }
}
