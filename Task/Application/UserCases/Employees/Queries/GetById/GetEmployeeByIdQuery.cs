using System.Threading.Tasks;
using Task.Presistence.IRepositories;

namespace Task.Application.UserCases.Employees.Queries.GetById
{
    public class GetEmployeeByIdQuery : IGetEmployeeByIdQuery
    {
        private readonly IEmployeeRepository employeeRepository;
        public GetEmployeeByIdQuery(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<GetEmployeeByIdResult> Execute(long employeeId)
        {
            var res = new GetEmployeeByIdResult();
            if (employeeId > 0)
            {
                var query = await employeeRepository.GetById(employeeId);
                if (query != null)
                {
                    res = new GetEmployeeByIdResult()
                    {
                        Id = query.Id,
                        CreatedBy = query.UpdatedBy,
                        UpdatedDate = query.UpdatedDate,
                        Address = query.Address,
                        Age = query.Age,
                        Email = query.Email,
                        ExperienceYear = query.ExperienceYear,
                        Position = query.Position,
                        MobilePhone = query.MobilePhone,
                        MilitaryStatus = query.MilitaryStatus,
                        MaritalStatus = query.MaritalStatus,
                        FirstName = query.FirstName,
                        Gender = query.Gender,
                        HiringDate = query.HiringDate,
                        BirthDate = query.BirthDate,
                        CreationDate = query.CreationDate,
                        DeletedBy = query.DeletedBy,
                        DeletionDate = query.DeletionDate,
                        IsDeleted = query.IsDeleted,
                        LastName = query.LastName,
                        UpdatedBy = query.UpdatedBy,
                    };
                }
            }

            return res;
        }
    }
}
