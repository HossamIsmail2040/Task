using System.Threading.Tasks;
using Task.Presistence.IRepositories;
using Task.Presistence.Repositories;

namespace Task.Application.UserCases.Login
{
    public class LoginCommand: ILoginCommand
    {
        private readonly IEmployeeRepository employeeRepository;

        public LoginCommand(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<AccessTokenResponse> Execute(LoginModel model) 
        {
            var res = await employeeRepository.GetAccessToken(model);
            return res;
        }
    }
}
