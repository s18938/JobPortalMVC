using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Industry
    {
        public Industry()
        {
            Experiences = new HashSet<Experience>();
            Joboffers = new HashSet<Joboffer>();
        }

        public int IndustryId { get; set; }
        public string IndustryName { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Joboffer> Joboffers { get; set; }
    }
}
