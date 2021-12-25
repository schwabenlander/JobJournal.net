using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public interface IApplicationMethodRepository
    {
        Task<ApplicationMethod> GetApplicationMethod(int id);
        IQueryable<ApplicationMethod> GetApplicationMethods();
    }
}
