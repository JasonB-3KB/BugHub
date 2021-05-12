using BugHub.Data;
using BugHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project()
                {
                    OwnerId = _userId,
                    ProjectName = model.ProjectName,
                    EmployeeId = model.EmployeeId,
                    CreatedUtc = model.CreatedUtc
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Projects
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProjectListItem
                        {
                            ProjectId = e.ProjectId,
                            ProjectName = e.ProjectName,
                            EmployeeId = e.EmployeeId,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<Project> GetProjectList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Projects.ToList();
            }
        }
        public ProjectDetail GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(e => e.ProjectId == id && e.OwnerId == _userId);
                return
                    new ProjectDetail
                    {
                        ProjectId = entity.ProjectId,
                        ProjectName = entity.ProjectName,
                        EmployeeId = entity.EmployeeId,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateProject(ProjectEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(e => e.ProjectId == model.ProjectId && e.OwnerId == _userId);

                entity.ProjectName = model.ProjectName;
                entity.EmployeeId = model.EmployeeId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProject(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(e => e.ProjectId == projectId && e.OwnerId == _userId);

                ctx.Projects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
