using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Clienttype
    {
        public Clienttype()
        {
            Experiences = new HashSet<Experience>();
            Joboffers = new HashSet<Joboffer>();
        }

        public int ClientTypeId { get; set; }
        public string ClientTypeName { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Joboffer> Joboffers { get; set; }
    }
}
