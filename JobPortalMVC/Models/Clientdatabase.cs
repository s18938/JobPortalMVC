using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Clientdatabase
    {
        public Clientdatabase()
        {
            Experiences = new HashSet<Experience>();
            Joboffers = new HashSet<Joboffer>();
        }

        public int ClientDatabaseId { get; set; }
        public string ClientDatabaseName { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Joboffer> Joboffers { get; set; }
    }
}
