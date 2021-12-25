using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class ApplicationStatusDTO
    {
        public int Id { get; set; }

        [Display(Name = "Application Status")]
        public string Status { get; set; }
    }
}
