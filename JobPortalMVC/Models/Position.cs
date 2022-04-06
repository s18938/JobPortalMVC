using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Position
    {
        public Position()
        {
            Experiences = new HashSet<Experience>();
            Joboffers = new HashSet<Joboffer>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Joboffer> Joboffers { get; set; }
    }
}
