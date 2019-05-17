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
            // Using localdb for testing.
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=RiskAssessmentsDB2;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Threat>()
                .HasOne(t => t.RiskAssessment)
                .WithMany(ra => ra.Threats)
                .HasForeignKey(t => t.RiskAssessmentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RiskAssessment>()
                .HasKey(ra => ra.Id);
        }

        public DbSet<RiskAssessment> RiskAssessments { get; set; }
        public DbSet<Threat> Threats { get; set; }
    }
}
