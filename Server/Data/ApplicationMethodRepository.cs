using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public class ApplicationMethodRepository : IApplicationMethodRepository
    {
        private readonly JobJournalContext _db;

        public ApplicationMethodRepository(JobJournalContext context)
        {
            _db = context;
        }

        public async Task<ApplicationMethod> GetApplicationMethod(int id)
        {
            return await _db.ApplicationMethods.FindAsync(id);
        }

        public IQueryable<ApplicationMethod> GetApplicationMethods()
        {
            return _db.ApplicationMethods;
        }
    }
}
