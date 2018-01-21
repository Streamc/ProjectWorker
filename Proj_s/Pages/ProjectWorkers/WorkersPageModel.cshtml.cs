using Proj_s.Data;
using Proj_s.Models;
using Proj_s.Models.ProjectView;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Proj_s.Pages.ProjectWorkers
{
    public class ProjectWorkersPageModel : PageModel
    {
        public List<AssignedWorkerData> AssignedWorkerDataList;

        public void PopulateAssignedWorkerData(ProjectContext context, Project project
                                              
                                               )
        {
            var allWorkers = context.Workers;
            var projectWorkers = new HashSet<int>(
                project.ProjectAssignment.Select(c=>c.WorkerID));
            AssignedWorkerDataList = new List<AssignedWorkerData>();
            foreach (var Worker in allWorkers)
            {
                AssignedWorkerDataList.Add(new AssignedWorkerData
                {
                    WorkerID = Worker.ID,
                    Name = Worker.Firstname,
                    Assigned = projectWorkers.Contains(Worker.ID)
                }
                
                    );
            }
        }

        public void UpdateProjectWorkers(ProjectContext context,
            string[] selectedWorkers, Project projectToUpdate)
        {
            if (selectedWorkers == null)
            {
                projectToUpdate.ProjectAssignment = new List<ProjectAssignment>();
                return;
            }

            var selectedWorkersHS = new HashSet<string>(selectedWorkers);
            var ProjectWorkers = new HashSet<int>
                (projectToUpdate.ProjectAssignment.Select(c => c.Worker.ID));
            foreach (var Worker in context.Workers)
            {
                if (selectedWorkersHS.Contains(Worker.ID.ToString()))
                {
                    if (!ProjectWorkers.Contains(Worker.ID))
                    {
                        projectToUpdate.ProjectAssignment.Add(
                            new ProjectAssignment
                            {
                                ProjectID = projectToUpdate.ID,
                                WorkerID = Worker.ID
                            });
                    }
                }
                else
                {
                    if (ProjectWorkers.Contains(Worker.ID))
                    {
                        ProjectAssignment WorkerToRemove
                            = projectToUpdate
                                .ProjectAssignment
                                .SingleOrDefault(i => i.WorkerID == Worker.ID);
                        context.Remove(WorkerToRemove);
                    }
                }
            }
        }











    }

}
