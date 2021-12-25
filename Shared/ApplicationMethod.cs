using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobJournal.Shared
{
    public class ApplicationMethod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Method { get; set; }
    }
}
