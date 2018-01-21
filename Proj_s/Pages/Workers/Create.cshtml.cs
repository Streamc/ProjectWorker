using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proj_s.Data;
using Proj_s.Models;

namespace Proj_s.Pages.Workers
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
            return Page();
        }

        [BindProperty]
        public Worker Worker { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workers.Add(Worker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}