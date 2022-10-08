using System.Threading.Tasks;

namespace Task.Application.UserCases.Employees.Commands.Create
{
    public interface ICreateEmployeeCommand
    {
        Task<long> Execute(CreateEmployeeModel model,string userId);
    }
}
