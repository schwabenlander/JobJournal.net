using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared
{
    public class JobApplication
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Company Company { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }

        [Required]
        public int ApplicationStatusId { get; set; }

        public ApplicationMethod ApplicationMethod { get; set; }

        [Required]
        public int ApplicationMethodId { get; set; }

        public string? OtherApplicationMethod { get; set; }

        public string? Notes { get; set; }
    }
}
