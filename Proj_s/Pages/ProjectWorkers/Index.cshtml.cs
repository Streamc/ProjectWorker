using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proj_s.Models;
using Proj_s.Models.ProjectView;

namespace Proj_s.Pages.ProjectWorkers
{
    public class IndexModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public IndexModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }

      
        public int ProjectID { get;  set; }
        public int WorkerID { get; set; }


        public ProjWorkers Project { get; set; }

        public async Task OnGetAsync(int? id, int? workerID)
        {
            Project = new ProjWorkers();
            Project.Projects = await _context.Projects
             .Include(i => i.ProjectAssignment)
             .ThenInclude(i => i.Project)
             .Include(i => i.ProjectAssignment)
             .ThenInclude(i => i.Worker)
             .AsNoTracking()
             .ToListAsync();

                if (id != null)
                {
                    ProjectID = id.Value;
                    Project project = Project.Projects.Where(
                        i => i.ID == id.Value).Single();
                     Project.Workers = project.ProjectAssignment.Select(s => s.Worker);
                }

                if (workerID != null)
                {
                    WorkerID = workerID.Value;
                    var selectedWorker = Project.Workers.Where(x => x.ID == workerID).Single();
                    await _context.Entry(selectedWorker).Collection(x => x.ProjectAssignment).LoadAsync();
                    //foreach (ProjectAssignment enrollment in selectedWorker.ProjectAssignment)
                   // {
                    //    await _context.Entry(enrollment).Reference(x => x.Worker).LoadAsync();
                    //}
                   //  Project.ProjectAssignments = selectedWorker.ProjectAssignment;
                }




        }
    }
}
