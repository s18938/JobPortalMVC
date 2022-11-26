using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Candidate
    {
        public Candidate()
        {
            Documents = new HashSet<Document>();
            Experiences = new HashSet<Experience>();
            Joboffercandidates = new HashSet<Joboffercandidate>();
        }

        public int CandidateId { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "Pole musi zawierać conajmniej 2 znaki")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Imie musi zaczynać się wielką literą")]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "Pole musi zawierać conajmniej 2 znaki")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Nazwisko musi zaczynać się wielką literą")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Wpisz poprawny email")]
        [EmailAddress]
        public string Email { get; set; }
        public int? CityCityId { get; set; }

        [DataType(DataType.PhoneNumber)]
        
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Wpisz poprawny nr telefonu")]
        public int? TelNum { get; set; }

        public virtual City CityCity { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Joboffercandidate> Joboffercandidates { get; set; }
    }
}
