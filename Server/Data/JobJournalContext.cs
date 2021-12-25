using JobJournal.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public class JobJournalContext : DbContext
    {
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<ApplicationMethod> ApplicationMethods { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyContact> CompanyContacts { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        public JobJournalContext(DbContextOptions<JobJournalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationMethod>().ToTable("ApplicationMethod");
            modelBuilder.Entity<ApplicationStatus>().ToTable("ApplicationStatus");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<CompanyContact>().ToTable("CompanyContact");
            modelBuilder.Entity<JobApplication>().ToTable("JobApplication");

            modelBuilder.Entity<ApplicationStatus>().HasData(
                new ApplicationStatus { Id = 1, Status = "Applied" },
                new ApplicationStatus { Id = 2, Status = "Interviewing" },
                new ApplicationStatus { Id = 3, Status = "Declined" },
                new ApplicationStatus { Id = 4, Status = "Rejected" },
                new ApplicationStatus { Id = 5, Status = "Ghosted" },
                new ApplicationStatus { Id = 6, Status = "Hired" }
            );

            modelBuilder.Entity<ApplicationMethod>().HasData(
                new ApplicationMethod { Id = 1, Method = "Direct (Online)" },
                new ApplicationMethod { Id = 2, Method = "Direct (Email)" },
                new ApplicationMethod { Id = 3, Method = "Direct (In-Person)" },
                new ApplicationMethod { Id = 4, Method = "Recruiter" },
                new ApplicationMethod { Id = 5, Method = "Friend" },
                new ApplicationMethod { Id = 6, Method = "LinkedIn" },
                new ApplicationMethod { Id = 7, Method = "Indeed" },
                new ApplicationMethod { Id = 8, Method = "Monster" },
                new ApplicationMethod { Id = 9, Method = "Other" }
            );
        }
    }
}
