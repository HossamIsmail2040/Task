using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Presistence.IRepositories;

namespace Task.Application.UserCases.Employees.Queries.GetAll
{
    public class GetAllEmployeesQuery : IGetAllEmployeeQuery
    {
        private readonly IEmployeeRepository employeeRepository;
        public GetAllEmployeesQuery(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
      
        public async Task<List<GetAllEmployeeResult>> Execute()
        {
            var res = new List<GetAllEmployeeResult>();
            var query = await employeeRepository.GetAll();
            if (query.Any())
            {
                res= query.Select(a => new GetAllEmployeeResult()
                {
                    Id = a.Id,
                    CreatedBy = a.UpdatedBy,
                    UpdatedDate = a.UpdatedDate,
                    Address = a.Address,
                    Age = a.Age,
                    Email = a.Email,
                    ExperienceYear = a.ExperienceYear,
                    Position = a.Position,
                    MobilePhone = a.MobilePhone,
                    MilitaryStatus = a.MilitaryStatus,
                    MaritalStatus = a.MaritalStatus,
                    FirstName = a.FirstName,
                    Gender = a.Gender,
                    HiringDate = a.HiringDate,
                    BirthDate = a.BirthDate,
                    CreationDate = a.CreationDate,
                    DeletedBy = a.DeletedBy,
                    DeletionDate = a.DeletionDate,
                    IsDeleted = a.IsDeleted,
                    LastName = a.LastName,
                    UpdatedBy = a.UpdatedBy,

                }).ToList();

            }
            return res;

        }
    }
}
