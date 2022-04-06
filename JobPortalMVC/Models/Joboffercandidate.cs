using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Joboffercandidate
    {
        public int JobOfferCandidateId { get; set; }
        public int JobOfferJobOfferId { get; set; }
        public int CandidateCandidateId { get; set; }
        public DateTime AddDate { get; set; }
        public int JobApliacationStateJobApliacationStateId { get; set; }

        public virtual Candidate CandidateCandidate { get; set; }
        public virtual Jobapliacationstate JobApliacationStateJobApliacationState { get; set; }
        public virtual Joboffer JobOfferJobOffer { get; set; }
    }
}
