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
    public class DetailsModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public DetailsModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }

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
    }
}
