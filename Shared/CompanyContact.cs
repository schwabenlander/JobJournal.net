using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace JobJournal.Shared
{
    public class CompanyContact
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Company Company { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public string PhoneNumber { get; set; }

        public string Notes { get; set; }

        public string EmailAddress { get; set; }

        public DateTime? FirstContactDate { get; set; }

        public DateTime? MostRecentContactDate { get; set; }
    }
}
