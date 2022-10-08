using System.Threading.Tasks;

namespace Task.Application.UserCases.Login
{
    public interface ILoginCommand
    {
        Task<AccessTokenResponse> Execute(LoginModel model);
    }
}
