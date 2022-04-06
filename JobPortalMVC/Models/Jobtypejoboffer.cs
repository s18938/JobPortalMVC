using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Jobtypejoboffer
    {
        public int JobTypeJobOfferId { get; set; }
        public int JobTypeJobTypeId { get; set; }
        public int JobOfferJobOfferId { get; set; }

        public virtual Joboffer JobOfferJobOffer { get; set; }
        public virtual Jobtype JobTypeJobType { get; set; }
    }
}
