using System.Threading.Tasks;

namespace Task.Application.UserCases.Employees.Commands.Update
{
    public interface IUpdateEmployeeCommand
    {
        Task<bool> Execute(UpdateEmployeeModel model,string userId);
    }
}
