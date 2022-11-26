using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Joboffer 
    {
        public Joboffer()
        {
            Joboffercandidates = new HashSet<Joboffercandidate>();
            Jobtypejoboffers = new HashSet<Jobtypejoboffer>();
        }

        public int JobOfferId { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Pole musi zawierać 10-1000 znaków")]
        public string Content { get; set; }

        //[DataType(DataType.Currency)]
        //[MinLength(4, ErrorMessage = "Pole musi zawierać conajmniej 4 znaki")]
        //[MaxLength(6, ErrorMessage = "Pole musi zawierać max 6 znaków")]
        public int? SalaryMax { get; set; }

        //[DataType(DataType.Currency)]
        //[MinLength(4, ErrorMessage = "Pole musi zawierać conajmniej 4 znaki")]
        //[MaxLength(6, ErrorMessage = "Pole musi zawierać max 6 znaków")]
        public int? SalaryMin { get; set; }

        //[DataType(DataType.Currency)]      
        //[MaxLength(6, ErrorMessage = "Pole musi zawierać max 6 znaków")]
        public int? CommissonMin { get; set; }

        //[DataType(DataType.Currency)]
        //[MaxLength(6, ErrorMessage = "Pole musi zawierać max 6 znaków")]
        public int? CommissonMax { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "Pole musi zawierać conajmniej 4 znaki")]
        public string Title { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public bool CompanyCar { get; set; }
        public int EmployerEmployerId { get; set; }
        public int ClientDatabaseClientDatabaseId { get; set; }
        public int IndustryIndustryId { get; set; }
        public int ClientTypeClientTypeId { get; set; }
        public int PositionPositionId { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int SalesCycleLengthSalesCycleLengthId { get; set; }
        public int CityCityId { get; set; }

        public virtual City CityCity { get; set; }
        public virtual Clientdatabase ClientDatabaseClientDatabase { get; set; }
        public virtual Clienttype ClientTypeClientType { get; set; }
        public virtual Employer EmployerEmployer { get; set; }
        public virtual Industry IndustryIndustry { get; set; }
        public virtual Position PositionPosition { get; set; }
        public virtual Salescyclelength SalesCycleLengthSalesCycleLength { get; set; }
        public virtual ICollection<Joboffercandidate> Joboffercandidates { get; set; }
        public virtual ICollection<Jobtypejoboffer> Jobtypejoboffers { get; set; }

       
    }
}
