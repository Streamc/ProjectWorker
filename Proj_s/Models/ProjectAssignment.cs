using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proj_s.Models
{
    public class ProjectAssignment
    {
        
        public int ProjectID { get; set; }
        public int WorkerID { get; set; }
        public Project Project { get; set; }
        public Worker Worker { get; set; }

    }
}
