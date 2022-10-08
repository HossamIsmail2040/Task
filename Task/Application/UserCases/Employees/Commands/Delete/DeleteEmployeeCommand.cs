using System.Threading.Tasks;
using Task.Application.UserCases.Employees.Queries.GetById;
using Task.Presistence.IRepositories;

namespace Task.Application.UserCases.Employees.Commands.Delete
{
    public class DeleteEmployeeCommand : IDeleteEmployeeCommand
    {
        private readonly IEmployeeRepository employeeRepository;
        public DeleteEmployeeCommand(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<bool> Execute(long employeeId,string userId)
        {
            var res = false;
            if (employeeId > 0)
            {
                var data = employeeRepository.Delete(employeeId,userId);
                if (data != null)
                {
                    res = true;
                }
            }

            return res;
        }
    }
}
