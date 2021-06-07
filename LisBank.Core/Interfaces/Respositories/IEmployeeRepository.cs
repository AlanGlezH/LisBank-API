using System.Threading.Tasks;
using LisBank.Core.Entities;

namespace LisBank.Core.Interfaces.Respositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAuth(int idAuthentication);
    }
}
