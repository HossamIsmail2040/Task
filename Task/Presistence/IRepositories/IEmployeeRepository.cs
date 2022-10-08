using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Task.Application.UserCases.Login;
using Task.Domain.ApplicationUser;
using Task.Domain.Employees;

namespace Task.Presistence.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<AccessTokenResponse> GetAccessToken(LoginModel model);
        Task<long> Create(Employee entity);
        Task<bool> Update(Employee entity);
        Task<bool> Delete(long id,string userId);
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(long id);
    }
}
