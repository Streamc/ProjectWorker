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
    public class DetailsModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public DetailsModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }

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
    }
}
