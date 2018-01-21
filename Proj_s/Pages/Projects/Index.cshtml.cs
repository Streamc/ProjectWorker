using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proj_s.Models;

namespace Proj_s.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly Proj_s.Data.ProjectContext _context;

        public IndexModel(Proj_s.Data.ProjectContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string Begin_date_Sort { get; set; }
        public string End_date_Sort { get; set; }

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            Begin_date_Sort = sortOrder == "Begin_date" ? "Begin_date_desc" : "Begin_date";
            End_date_Sort = sortOrder == "End_date" ? "End_date_desc" : "End_date";

            IQueryable<Project> projectquery = from s in _context.Projects
                                            select s;
            //git bkj
            switch (sortOrder)
            {/////
                case "name_desc":
                    projectquery = projectquery.OrderByDescending(s => s.Name);
                    break;
                case "Begin_date":
                    projectquery = projectquery.OrderBy(s => s.Begin_date);
                    break;
                case "Begin_date_desc":
                    projectquery = projectquery.OrderByDescending(s => s.Begin_date);
                    break;
                case "End_date":
                    projectquery = projectquery.OrderBy(s => s.End_date);
                    break;
                case "End_date_desc":
                    projectquery = projectquery.OrderByDescending(s => s.End_date);
                    break;
                default:
                    projectquery = projectquery.OrderBy(s => s.Name);
                    break;//
            }
            //

            Project = await projectquery.AsNoTracking().ToListAsync();
        }
    }
}
