using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public byte[] File { get; set; }
        public int CandidateCandidateId { get; set; }

        public virtual Candidate CandidateCandidate { get; set; }
    }
}
