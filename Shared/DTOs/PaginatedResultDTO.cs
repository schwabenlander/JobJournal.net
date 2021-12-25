using System;
using System.Collections.Generic;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class PaginatedResultDTO<T>
    {
        public List<T> Results { get; set; }

        public int TotalRecords { get; set; }

        public int RecordsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
