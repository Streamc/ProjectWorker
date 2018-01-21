using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proj_s.Models;

using Microsoft.AspNetCore.Mvc;
using System;
namespace Proj_s.Pages.ProjectWorkers
{
    public class EditModel : ProjectWorkersPageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public EditModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects
                .Include(i => i.ProjectAssignment)
                .ThenInclude(i => i.Worker)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Project == null)
            {
                return NotFound();
            }
            PopulateAssignedWorkerData(_context, Project);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedWorkers)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var projectToUpdate = await _context.Projects
                .Include(i => i.ProjectAssignment)    
                    .ThenInclude(i => i.Worker)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Project>(
                projectToUpdate,
                "Project",
                i => i.ID, i => i.Name,i => i.ManagerID, i => i.ProjectAssignment))
            {
             /*   if (String.IsNullOrWhiteSpace(
                    projectToUpdate.ProjectAssignment.Wor))
                {
                    projectToUpdate.ProjectAssignment = null;
               }*/
                UpdateProjectWorkers(_context, selectedWorkers, projectToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateProjectWorkers(_context, selectedWorkers, projectToUpdate);
            PopulateAssignedWorkerData(_context, projectToUpdate);
            return Page();
        }

    
    }
}