using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HumanRisksAssignment.Models
{
    public class RiskAssessmentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Using MSSQL localdb for testing.
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=RiskAssessmentsDB2;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Threat>()
                .HasOne(t => t.RiskAssessment)
                .WithMany(ra => ra.Threats)
                .HasForeignKey(t => t.RiskAssessmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<RiskAssessment>()
                .HasKey(ra => ra.Id);

            // Seeding initial data
            modelBuilder.Entity<RiskAssessment>().HasData(
                new RiskAssessment
                {
                    Id = new Guid("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"),
                    Title = "Risk Assessment 1",
                    Latitude = 57.054517,
                    Longitude = 9.9093796,
                    Threats = new List<Threat>()
                },
                new RiskAssessment
                {
                    Id = new Guid("32ca327a-8fee-44f4-9401-2304ca6b55ad"),
                    Title = "Risk Assessment 2",
                    Latitude = 57.0359697,
                    Longitude = 9.9329562,
                    Threats = new List<Threat>()
                });

            modelBuilder.Entity<Threat>().HasData(
                    new Threat
                    {
                        Id = Guid.NewGuid(),
                        Title = "Some threat",
                        Level = 0,
                        RiskAssessmentId = Guid.Parse("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f")
                    },
                    new Threat
                    {
                        Id = Guid.NewGuid(),
                        Title = "Some other threat",
                        Level = 2,
                        RiskAssessmentId = Guid.Parse("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f")
                    },
                    new Threat
                    {
                        Id = Guid.NewGuid(),
                        Title = "This is a threat",
                        Level = 2,
                        RiskAssessmentId = Guid.Parse("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f")
                    },
                    new Threat
                    {
                        Id = Guid.NewGuid(),
                        Title = "Some failure threat",
                        Level = 1,
                        RiskAssessmentId = Guid.Parse("32ca327a-8fee-44f4-9401-2304ca6b55ad")
                    },
                    new Threat
                    {
                        Id = Guid.NewGuid(),
                        Title = "Some unknown threat",
                        Level = 1,
                        RiskAssessmentId = Guid.Parse("32ca327a-8fee-44f4-9401-2304ca6b55ad")
                    });
        }

        public DbSet<RiskAssessment> RiskAssessments { get; set; }
        public DbSet<Threat> Threats { get; set; }
    }
}
