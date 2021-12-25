using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string WebsiteURI { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Notes { get; set; }
    }
}
