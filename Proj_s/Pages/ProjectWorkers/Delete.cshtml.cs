using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proj_s.Data;
using Proj_s.Models;

namespace Proj_s.Pages.ProjectWorkers
{
    public class DeleteModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public DeleteModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectAssignment ProjectAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectAssignment = await _context.ProjectAssignments
                .Include(p => p.Project)
                .Include(p => p.Worker).SingleOrDefaultAsync(m => m.ProjectID == id);

            if (ProjectAssignment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectAssignment = await _context.ProjectAssignments.FindAsync(id);

            if (ProjectAssignment != null)
            {
                _context.ProjectAssignments.Remove(ProjectAssignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
