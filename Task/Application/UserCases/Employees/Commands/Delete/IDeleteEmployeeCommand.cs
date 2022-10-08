using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Task.Application.UserCases.Employees.Commands.Delete
{
    public interface IDeleteEmployeeCommand
    {
        Task<bool> Execute(long employeeId,string userId);
    }
}
