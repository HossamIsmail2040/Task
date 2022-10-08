using System;
using System.Threading.Tasks;
using Task.Domain.Employees;
using Task.Presistence.IRepositories;

namespace Task.Application.UserCases.Employees.Commands.Create
{
    public class CreateEmployeeCommand : ICreateEmployeeCommand
    {
        private readonly IEmployeeRepository employeeRepository;
        public CreateEmployeeCommand(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public Task<long> Execute(CreateEmployeeModel model, string userId)
        {
            if (model == null)
            {
                throw new Exception("invalid model");
            }

            var employee = new Employee()
            {
                Address = model.Address,
                Age = model.Age,
                BirthDate = model.BirthDate,
                CreatedBy = userId,
                CreationDate = DateTime.UtcNow,
                Email = model.Email,
                ExperienceYear = model.ExperienceYear,
                FirstName = model.FirstName,
                Gender = model.Gender,
                Position = model.Position,
                HiringDate = model.HiringDate,
                LastName = model.LastName,
                MaritalStatus = model.MaritalStatus,
                MilitaryStatus=model.MilitaryStatus,
                MobilePhone=model.MobilePhone,
            };

            var res = employeeRepository.Create(employee);
            return res;

        }
    }
}
