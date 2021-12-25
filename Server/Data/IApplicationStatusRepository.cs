using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public interface IApplicationStatusRepository
    {
        Task<ApplicationStatus> GetApplicationStatus(int id);
        IQueryable<ApplicationStatus> GetApplicationStatuses();
    }
}
