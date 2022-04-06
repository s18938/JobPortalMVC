using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Experience
    {
        public int ExperienceId { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "Pole musi zawierać conajmniej 2 znaki")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage ="Nazwa firmy musi zaczynać się wielką literą")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Data rozpoczęcia")]
        [DataType(DataType.Date, ErrorMessage ="Nieprawidłowa data")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Data zakończenia")]
        [DataType(DataType.Date, ErrorMessage ="Nieprawidłowa data")]
        public DateTime? EndDate { get; set; }
        public int CandidateCandidateId { get; set; }
        public int ClientDatabaseClientDatabaseId { get; set; }
        public int IndustryIndustryId { get; set; }
        public int ClientTypeClientTypeId { get; set; }
        public int PositionPositionId { get; set; }
        public int SalesCycleLengthSalesCycleLengthId { get; set; }

        public virtual Candidate CandidateCandidate { get; set; }
        public virtual Clientdatabase ClientDatabaseClientDatabase { get; set; }
        public virtual Clienttype ClientTypeClientType { get; set; }
        public virtual Industry IndustryIndustry { get; set; }
        public virtual Position PositionPosition { get; set; }
        public virtual Salescyclelength SalesCycleLengthSalesCycleLength { get; set; }
    }
}
