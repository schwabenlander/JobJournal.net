using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public class ApplicationStatusRepository : IApplicationStatusRepository
    {
        private readonly JobJournalContext _db;

        public ApplicationStatusRepository(JobJournalContext context)
        {
            _db = context;
        }

        public async Task<ApplicationStatus> GetApplicationStatus(int id)
        {
            return await _db.ApplicationStatuses.FindAsync(id);
        }

        public IQueryable<ApplicationStatus> GetApplicationStatuses()
        {
            return _db.ApplicationStatuses;
        }
    }
}
