using System.Threading.Tasks;

namespace Task.Application.UserCases.Employees.Queries.GetById
{
    public interface IGetEmployeeByIdQuery
    {
        Task<GetEmployeeByIdResult> Execute(long employeeId);
    }
}
