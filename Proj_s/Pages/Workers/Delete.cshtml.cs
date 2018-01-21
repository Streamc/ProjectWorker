using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proj_s.Data;
using Proj_s.Models;

namespace Proj_s.Pages.Workers
{
    public class DeleteModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public DeleteModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _context.Workers.SingleOrDefaultAsync(m => m.ID == id);

            if (Worker == null)
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

            Worker = await _context.Workers.FindAsync(id);

            if (Worker != null)
            {
                _context.Workers.Remove(Worker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
