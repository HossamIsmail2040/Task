using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.Application.UserCases.Employees.Queries.GetAll
{
    public interface IGetAllEmployeeQuery
    {
        Task<List<GetAllEmployeeResult>> Execute();
    }
}
