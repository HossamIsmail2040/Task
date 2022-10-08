using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task.Common;
using Task.Domain.Common;

namespace Task.Domain.Employees
{
    [Table(nameof(Employee))]
    public class Employee: IBaseEntity
    {
        [Key]
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

        //common
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DeletionDate { get; set; }
        public string DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
