using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Salescyclelength
    {
        public Salescyclelength()
        {
            Experiences = new HashSet<Experience>();
            Joboffers = new HashSet<Joboffer>();
        }

        public int SalesCycleLengthId { get; set; }
        public string SalesCycleLengthName { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Joboffer> Joboffers { get; set; }
    }
}
