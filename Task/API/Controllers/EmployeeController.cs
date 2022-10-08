using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task.Application.UserCases.Employees.Commands.Create;
using Task.Application.UserCases.Employees.Commands.Delete;
using Task.Application.UserCases.Employees.Commands.Update;
using Task.Application.UserCases.Employees.Queries.GetAll;
using Task.Application.UserCases.Employees.Queries.GetById;
using Task.Application.UserCases.Login;
using Task.Common;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<AccessTokenResponse> Login([FromBody] LoginModel model, [FromServices] ILoginCommand command)
        {
            var res = await command.Execute(model);
            return res;
        }

        [HttpPost("Create")]
        [Authorize]
        public Task<long> Create([FromBody] CreateEmployeeModel model, [FromServices] ICreateEmployeeCommand command)
        {
            var token = Request.Headers["Authorization"].ToString();
            var userId = Helpers.GetUserId(token);
            var res = command.Execute(model, userId);
            return res;
        }

        [HttpPost("Update")]
        [Authorize]
        public Task<bool> Update([FromBody] UpdateEmployeeModel model, [FromServices] IUpdateEmployeeCommand command)
        {
            var token = Request.Headers["Authorization"].ToString();
            var userId = Helpers.GetUserId(token);
            var res = command.Execute(model, userId);
            return res;
        }

        [HttpPost("Delete")]
        [Authorize]
        public Task<bool> Delete(long employeeId, [FromServices] IDeleteEmployeeCommand command)
        {
            var token = Request.Headers["Authorization"].ToString();
            var userId = Helpers.GetUserId(token);
            var res = command.Execute(employeeId, userId);
            return res;
        }

        [HttpGet("GetAll")]
        [Authorize]
        public Task<List<GetAllEmployeeResult>> GetAll([FromServices] IGetAllEmployeeQuery query)
        {
            var res = query.Execute();
            return res;
        }

        [HttpGet("GetById")]
        [Authorize]
        public Task<GetEmployeeByIdResult> GetById(long employeeId, [FromServices] IGetEmployeeByIdQuery query)
        {
            var res = query.Execute(employeeId);
            return res;
        }
    }
}
