using PetShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.App.Services
{
    public class EmployeeInMemoryDataService : IEmployeeDataService
    {
        private readonly IEnumerable<Employee> _employees;
        private readonly List<Country> _countries;
        private readonly List<JobCategory> _jobCategories;

        public EmployeeInMemoryDataService()
        {
            _jobCategories = new List<JobCategory>
            {
                new JobCategory { JobCategoryId = 1, JobCategoryName = "Pet research" },
                new JobCategory { JobCategoryId = 2, JobCategoryName = "Sales" },
                new JobCategory { JobCategoryId = 3, JobCategoryName = "Management" },
                new JobCategory { JobCategoryId = 4, JobCategoryName = "Store staff" },
                new JobCategory { JobCategoryId = 5, JobCategoryName = "Finance" },
                new JobCategory { JobCategoryId = 6, JobCategoryName = "QA" },
                new JobCategory { JobCategoryId = 7, JobCategoryName = "IT" },
                new JobCategory { JobCategoryId = 8, JobCategoryName = "Cleaning" }
            };

            _countries = new List<Country>
            {
                new Country { CountryId = 1, Name = "Germany" },
                new Country { CountryId = 2, Name = "Netherlands" },
                new Country { CountryId = 3, Name = "USA" },
                new Country { CountryId = 4, Name = "Japan" },
                new Country { CountryId = 5, Name = "China" },
                new Country { CountryId = 6, Name = "UK" },
                new Country { CountryId = 7, Name = "France" },
                new Country { CountryId = 8, Name = "Brazil" }
            };

            _employees = new List<Employee>
            {
                new Employee
                {
                    CountryId = 1,
                    MaritalStatus = MaritalStatus.Single,
                    BirthDate = new DateTime(1989, 3, 11),
                    City = "Nuremberg",
                    Email = "max.vogel@petshop.de",
                    EmployeeId = 1,
                    FirstName = "Max",
                    LastName = "Vogel",
                    Gender = Gender.Male,
                    PhoneNumber = "123456789",
                    Smoker = false,
                    Street = "Sesamstraße 17",
                    Zip = "1000",
                    JobCategoryId = 1,
                    Comment = "Lorem ipsum",
                    ExitDate = null,
                    JoinedDate = new DateTime(2015, 3, 1)
                },
                new Employee
                {
                    CountryId = 2,
                    MaritalStatus = MaritalStatus.Married,
                    BirthDate = new DateTime(1979, 1, 16),
                    City = "Amsterdam",
                    Email = "petra.wuff@petshop.de",
                    EmployeeId = 2,
                    FirstName = "Petra",
                    LastName = "Wuff",
                    Gender = Gender.Female,
                    PhoneNumber = "987654321",
                    Smoker = false,
                    Street = "New Street. 123",
                    Zip = "2000",
                    JobCategoryId = 1,
                    Comment = "Lorem ipsum",
                    ExitDate = null,
                    JoinedDate = new DateTime(2017, 12, 24)
                }
            };
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return Task.FromResult(_employees);
        }

        public Task<Employee> GetEmployee(int employeeId)
        {
            return Task.FromResult(_employees.FirstOrDefault(e => e.EmployeeId == employeeId));
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
