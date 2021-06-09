using System;
using System.Linq;
using System.Threading.Tasks;
using LisBank.Core.Entities;
using LisBank.Core.Interfaces.Respositories;
using LisBank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LisBank.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly LisBankContext _context;

        public EmployeeRepository(LisBankContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeByIdAuth(int idAuthentication)
        {
            var employee = await _context.Employees
                .Where(employee => employee.IdAuthentication == idAuthentication)
                .Include(employee => employee.Role)
                .FirstOrDefaultAsync();

            return employee;
        }
    }
}
