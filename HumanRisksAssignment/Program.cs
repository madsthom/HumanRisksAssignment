using HumanRisksAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace HumanRisksAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Printing all RiskAssessments:");
            var raList = GetRiskAssessments();
            raList.ForEach(PrintRiskAssessment); // Prints all RiskAssessments and threats

            Console.WriteLine("2. Single RiskAssessment:");
            var ra = GetRiskAssessmentById(Guid.Parse("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"));
            PrintRiskAssessment(ra);

            Console.WriteLine("3. Updated single RiskAssessment: ");
            ra.Latitude = 90.0;
            ra.Longitude = 0.0;
            AddOrUpdateRiskAssessment(ra);
            PrintRiskAssessment(ra);

            Console.WriteLine("4. Printing All RiskAssessments again:");
            raList = GetRiskAssessments(); // Update list
            raList.ForEach(PrintRiskAssessment);

            Console.WriteLine("5. Add new threat:");
            ra.Threats.Add(new Threat() {Title = "A very new threat", Level = 1});
            AddOrUpdateRiskAssessment(ra);
            PrintRiskAssessment(ra);

            Console.WriteLine("6. Remove threats:\n" +
                              "RiskAssessment before:");
            ra = GetRiskAssessmentById(Guid.Parse("32ca327a-8fee-44f4-9401-2304ca6b55ad"));
            PrintRiskAssessment(ra);
            ra.Threats.RemoveAll(t => t.Id == Guid.Parse("390A5AD4-80FF-492F-9565-04883F9C80BC"));
            AddOrUpdateRiskAssessment(ra);
            Console.WriteLine("RiskAssessment after:");
            PrintRiskAssessment(ra);

            RemoveRiskAssessment(ra);

        }

        public static void PrintRiskAssessment(RiskAssessment ra)
        {
            Console.WriteLine($"Assessment: {ra.Title}\n" +
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
                db.Database.EnsureCreated();
                return db.RiskAssessments
                    .Include(ra => ra.Threats)
                    .ToList();
            }
        }
    }
}
