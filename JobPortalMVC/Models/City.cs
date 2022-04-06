using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class City
    {
        public City()
        {
            Candidates = new HashSet<Candidate>();
            Joboffers = new HashSet<Joboffer>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Joboffer> Joboffers { get; set; }
    }
}
