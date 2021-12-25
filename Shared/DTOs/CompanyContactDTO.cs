using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class CompanyContactDTO
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        public string EmailAddress { get; set; }

        public string Notes { get; set; }

        [Display(Name = "First Contact")]
        [DataType(DataType.Date)]
        public DateTime? FirstContactDate { get; set; }

        [Display(Name = "Most Recent Contact")]
        [DataType(DataType.Date)]
        public DateTime? MostRecentContactDate { get; set; }
    }
}
