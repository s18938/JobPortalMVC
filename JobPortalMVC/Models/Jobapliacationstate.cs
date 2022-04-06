using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Jobapliacationstate
    {
        public Jobapliacationstate()
        {
            Joboffercandidates = new HashSet<Joboffercandidate>();
        }

        public int JobApliacationStateId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Joboffercandidate> Joboffercandidates { get; set; }
    }
}
