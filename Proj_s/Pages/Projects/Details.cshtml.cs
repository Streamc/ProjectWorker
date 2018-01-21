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
    public class DetailsModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public DetailsModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }

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
    }
}
