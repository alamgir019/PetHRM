using System;

namespace PetHRM.Repository.Data.Model
{
    public class Employee : BaseEntity
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }

    }

    public class BaseEntity
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
