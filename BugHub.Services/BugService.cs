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
                    //BugStatus = model.BugStatus,
                    //BugPriority = model.BugPriority,
                    //BugType = model.BugType,
                    //Employee = model.Employee.EmployeeId,
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
                            //BugStatus = e.BugStatus,
                            //BugPriority = e.BugPriority,
                            //BugType = e.BugType,
                            //EmployeeId = e.Employee.EmployeeId,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
