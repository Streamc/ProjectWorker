using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proj_s.Data;
using Proj_s.Models;

namespace Proj_s.Pages.ProjectWorkers
{
    public class CreateModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public CreateModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ID");
        ViewData["WorkerID"] = new SelectList(_context.Workers, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public ProjectAssignment ProjectAssignment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProjectAssignments.Add(ProjectAssignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}