using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Jobtype
    {
        public Jobtype()
        {
            Jobtypejoboffers = new HashSet<Jobtypejoboffer>();
        }

        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }

        public virtual ICollection<Jobtypejoboffer> Jobtypejoboffers { get; set; }
    }
}
