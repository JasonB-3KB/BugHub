using BugHub.Data;
using BugHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    OwnerId = _userId,
                    EmployeeEmail = model.EmployeeEmail,
                    EmployeeRole = model.EmployeeRole,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Employees
                    //.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new EmployeeListItem
                        {
                            EmployeeId = e.EmployeeId,
                            EmployeeEmail = e.EmployeeEmail,
                            EmployeeRole = e.EmployeeRole,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<Employee> GetEmployeeList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Employees.ToList();
            }
        }
    }
}
