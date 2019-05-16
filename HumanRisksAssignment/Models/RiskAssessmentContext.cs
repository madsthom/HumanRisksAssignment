using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanRisksAssignment.Models
{
    public class RiskAssessmentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Using localdb for testing. TODO: Change connection string to dev of prod db.
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=RiskAssessmentsDB2;Integrated Security=True");
        }

        public DbSet<RiskAssessment> RiskAssessments { get; set; }
        public DbSet<Threat> Threats { get; set; }
    }
}
