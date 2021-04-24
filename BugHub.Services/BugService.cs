using BugHub.Data;
using BugHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Services
{
    public class BugService
    {
        private readonly Guid _userId;

        public BugService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBug(BugCreate model)
        {
            var entity =
                new Bug()
                {
                    OwnerId = _userId,
                    BugTitle = model.BugTitle,
                    BugDescription = model.BugDescription,
                    BugStatus = model.BugStatus,
                    BugPriority = model.BugPriority,
                    BugType = model.BugType,
                    EmployeeId = model.EmployeeId,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bugs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BugListItem> GetBugs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Bugs
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new BugListItem
                        {
                            BugId = e.BugId,
                            BugTitle = e.BugTitle,
                            BugStatus = e.BugStatus,
                            BugPriority = e.BugPriority,
                            BugType = e.BugType,
                            EmployeeId = e.Project.EmployeeId,
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


        public BugDetail GetBugById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Bugs
                    .Single(e => e.BugId == id && e.OwnerId == _userId);
                return
                    new BugDetail
                    {
                        BugId = entity.BugId,
                        BugTitle = entity.BugTitle,
                        BugDescription = entity.BugDescription,
                        BugStatus = entity.BugStatus,
                        BugPriority = entity.BugPriority,
                        BugType = entity.BugType,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                        
                    };
            }
        }
    }
}
