using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class Employer
    {
        public Employer()
        {
            Joboffers = new HashSet<Joboffer>();
        }

        public int EmployerId { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Pole musi zawierać conajmniej 2 znaki")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Nazwa firmy musi zaczynać się wielką literą")]
        public string Name { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DataType(DataType.Upload, ErrorMessage = "Błąd")]
        public byte[] Logo { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Nazwa firmy musi zaczynać się wielką literą")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Wpisz poprawny email")]
        [EmailAddress]
        public string Email { get; set; }
        public int? EmployeesNumber { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Wpisz poprawny URL")]
        public string Page { get; set; }

        public virtual ICollection<Joboffer> Joboffers { get; set; }
    }
}
