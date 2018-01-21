using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj_s.Models.ProjectView
{
    public class ProjWorkers
    {

        public IEnumerable<ProjectAssignment> ProjectAssignments { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Worker> Workers { get; set; }
    }
}




