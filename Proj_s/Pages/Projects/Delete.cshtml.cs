using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proj_s.Data;
using Proj_s.Models;

namespace Proj_s.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public DeleteModel(Proj_s.Data.ProjectContext context)
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

            Project = await _context.Projects.SingleOrDefaultAsync(m => m.ID == id);

            if (Project == null)
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

            Project = await _context.Projects.FindAsync(id);

            if (Project != null)
            {
                _context.Projects.Remove(Project);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
