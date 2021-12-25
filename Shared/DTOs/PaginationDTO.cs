using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;

        public int RecordsPerPage { get; set; } = 20;
    }
}
