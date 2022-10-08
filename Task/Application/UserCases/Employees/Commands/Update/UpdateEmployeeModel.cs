using System;
using Task.Common;

namespace Task.Application.UserCases.Employees.Commands.Update
{
    public class UpdateEmployeeModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public float ExperienceYear { get; set; }
        public DateTime HiringDate { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }

    }
}
