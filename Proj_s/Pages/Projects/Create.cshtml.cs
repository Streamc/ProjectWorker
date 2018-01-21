using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proj_s.Models;
using System.Web;

namespace Proj_s.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public CreateModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }
        //
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}