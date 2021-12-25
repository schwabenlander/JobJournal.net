using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class ApplicationMethodDTO
    {
        public int Id { get; set; }

        [Display(Name = "Application Method")]
        public string Method { get; set; }
    }
}
