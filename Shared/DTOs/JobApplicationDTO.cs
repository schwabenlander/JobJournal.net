using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class JobApplicationDTO
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Company is required")]
        public Guid CompanyId { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Date of Application")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }

        [Required(ErrorMessage = "Application Method is required")]
        public int ApplicationMethodId { get; set; }

        [Display(Name = "Application Method")]
        public string ApplicationMethod { get; set; }

        [Required(ErrorMessage = "Application Status is required")]
        public int ApplicationStatusId { get; set; }

        [Display(Name = "Application Status")]
        public string ApplicationStatus { get; set; }

        [Display(Name = "Other Application Method")]
        public string OtherApplicationMethod { get; set; }

        public string Notes { get; set; }
    }
}
