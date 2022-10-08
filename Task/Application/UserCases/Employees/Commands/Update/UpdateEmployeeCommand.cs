using System;
using System.Threading.Tasks;
using Task.Domain.Employees;
using Task.Presistence.IRepositories;

namespace Task.Application.UserCases.Employees.Commands.Update
{
    public class UpdateEmployeeCommand : IUpdateEmployeeCommand
    {
        private readonly IEmployeeRepository employeeRepository;
        public UpdateEmployeeCommand(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<bool> Execute(UpdateEmployeeModel model,string userId)
        {
            var res = false;
            if (model == null)
            {
                throw new Exception("invalid model");
            }

            var data = await employeeRepository.GetById(model.Id);
            if (data != null)
            {
                data.UpdatedBy = userId;
                data.UpdatedDate = DateTime.UtcNow;
                data.Address = model.Address;
                data.Age = model.Age;
                data.Email = model.Email;
                data.ExperienceYear = model.ExperienceYear;
                data.Position = model.Position;
                data.MobilePhone = model.MobilePhone;
                data.MilitaryStatus = model.MilitaryStatus;
                data.MaritalStatus = model.MaritalStatus;
                data.FirstName = model.FirstName;
                data.Gender = model.Gender;
                data.HiringDate = model.HiringDate;

                var query = await employeeRepository.Update(data);
                if (query)
                {
                    res = true;
                }
            }

            return res;
        }
    }
}
