using HumanRisksAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanRisksAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new RiskAssessmentContext())
            {
                // Ensures that db is created else the db is migrated automatically
                db.Database.EnsureCreated();
            }

            // Add new RiskAssessment
            AddOrUpdateRiskAssessment(
                new RiskAssessment {
                    Title = "A new RiskAssessment 3",
                    Latitude = 57,
                    Longitude = 120,
                    Threats = new List<Threat>()
                    {
                        new Threat() {Title = "A new threat", Level = 2},
                        new Threat() {Title = "Another new threat", Level = 1}
                    }});

            Console.WriteLine("1. Printing all RiskAssessments:");
            var raList = GetRiskAssessments();
            raList.ForEach(PrintRiskAssessment); // Prints all RiskAssessments and threats

            Console.WriteLine("2. Single RiskAssessment:");
            var ra1 = GetRiskAssessmentById(Guid.Parse("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"));
            PrintRiskAssessment(ra1);

            Console.WriteLine("3. Updated single RiskAssessment: ");
            ra1.Title = "This is the new title"; // Update RiskAssessment
            ra1.Latitude = 90.0;
            ra1.Longitude = 0.0;
            AddOrUpdateRiskAssessment(ra1);
            PrintRiskAssessment(ra1);

            Console.WriteLine("4. Add new threat:");
            ra1.Threats.Add(new Threat() {Title = "A very new threat", Level = 1});
            AddOrUpdateRiskAssessment(ra1);
            PrintRiskAssessment(ra1);

            Console.WriteLine("5. Remove threats:\n\n" +
                              "RiskAssessment before:\n");
            PrintRiskAssessment(ra1);
            RemoveThreat(ra1.Threats.Single(t => t.Title == "A very new threat"));

            Console.WriteLine("RiskAssessment after:\n");
            ra1 = GetRiskAssessmentById(Guid.Parse("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f")); // Get RA from db again
            PrintRiskAssessment(ra1);

            RemoveRiskAssessment(raList.First()); // Removes a RiskAssessment

            Console.WriteLine("6. Printing All RiskAssessments again:");
            raList = GetRiskAssessments(); // Update list
            raList.ForEach(PrintRiskAssessment);

        }

        public static void PrintRiskAssessment(RiskAssessment ra)
        {
            Console.WriteLine($"Assessment: {ra.Title}\n" +
                              $"Id: {ra.Id}\n" +
                              $"Lat: {ra.Latitude}\n" +
                              $"Long: {ra.Longitude}\n" +
                              "Threats:");
            foreach (var t in ra.Threats)
            {
                Console.WriteLine($"    {t.Title}:");
                Console.WriteLine($"    Level: {t.Level}");
            }

            Console.WriteLine();
        }

        public static void AddOrUpdateRiskAssessment(RiskAssessment ra)
        {
            using (var db = new RiskAssessmentContext())
            {
                if (db.RiskAssessments.Any(r => r.Id == ra.Id))
                {
                    db.RiskAssessments.Update(ra);
                }
                else
                {
                    db.RiskAssessments.Add(ra);
                }

                db.SaveChanges();
            }
        }

        public static bool RemoveRiskAssessment(RiskAssessment ra)
        {
            using (var db = new RiskAssessmentContext())
            {
                db.RiskAssessments.Remove(ra);
                return (db.SaveChanges() == 1);
            }
        }

        public static bool RemoveThreat(Threat t)
        {
            using (var db = new RiskAssessmentContext())
            {
                db.Threats.Remove(t);
                return (db.SaveChanges() == 1);
            }
        }

        public static RiskAssessment GetRiskAssessmentById(Guid guid)
        {
            using (var db = new RiskAssessmentContext())
            {
                return db.RiskAssessments
                    .Include(ra => ra.Threats)
                    .Single(r => r.Id == guid);

            }
        }

        public static List<RiskAssessment> GetRiskAssessments()
        {
            using (var db = new RiskAssessmentContext())
            {
                return db.RiskAssessments
                    .Include(ra => ra.Threats)
                    .ToList();
            }
        }
    }
}
