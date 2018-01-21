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
    public class IndexModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public IndexModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<Worker> Worker { get;set; }

        public async Task OnGetAsync()
        {
            Worker = await _context.Workers.ToListAsync();
        }
    }
}
