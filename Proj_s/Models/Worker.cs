using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj_s.Models
{
    public class Worker
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fathername { get; set; }
        public string email { get; set; }
        public string Company_name { get; set; }
        public ICollection<ProjectAssignment> ProjectAssignment { get; set; }

    }
}
