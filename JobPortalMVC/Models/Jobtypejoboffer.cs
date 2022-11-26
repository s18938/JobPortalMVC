using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Jobtypejoboffer
    {
        public int JobTypeJobOfferId { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public int JobTypeJobTypeId { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public int JobOfferJobOfferId { get; set; }

        public virtual Joboffer JobOfferJobOffer { get; set; }
        public virtual Jobtype JobTypeJobType { get; set; }
    }
}
