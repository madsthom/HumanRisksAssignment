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
                // If db is empty instantiate objects
                if (!db.RiskAssessments.Any())
                {
                    // Instantiate a RiskAssessment and Threats
                    var ra1 = new RiskAssessment("Some Assessment", 57.054517, 9.9093796);
                    var ra2 = new RiskAssessment("Some Assessment", 57.0359697, 9.9329562);
                    var t1 = new Threat("Some Threat", 1);
                    var t2 = new Threat("Some Minor Threat", 0);
                    var t3 = new Threat("Some Major Threat", 2);
                    var t4 = new Threat("Threaty", 1);
                    var t5 = new Threat("Threat Of All Threats", 2);

                    ra1.Threats.Add(t1); // Add Threats to RiskAssessment
                    ra1.Threats.Add(t2);
                    ra2.Threats.Add(t3);
                    ra2.Threats.Add(t4);
                    ra2.Threats.Add(t5);

                    db.RiskAssessments.Add(ra1);
                    db.RiskAssessments.Add(ra2);
                    db.SaveChanges();
                }
            }

            using (var db = new RiskAssessmentContext())
            {
                // Fetch RiskAssessments from db including Threats
                var raList = db.RiskAssessments.Include(r => r.Threats).ToList();

                PrintRiskAssessments(raList);

                raList[0].Title = "This is a new title";
                raList[0].Latitude = 56.0945342;
                raList[0].Longitude = 9.9625582;

                PrintRiskAssessments(raList);

                raList[0].Threats.RemoveAll(t => t.Level == 0);

                PrintRiskAssessments(raList);

                var t6 = new Threat("A very new threat", 2);

                raList[0].Threats.Add(t6);

                PrintRiskAssessments(raList);

                db.SaveChanges();

            }
        }

        public static void PrintRiskAssessments(List<RiskAssessment> raList)
        {
            // Go through RiskAssessments and write to console
            foreach (RiskAssessment ra in raList)
            {
                Console.WriteLine($"RA: {ra.Title}");
                Console.WriteLine($"Lat: {ra.Latitude}");
                Console.WriteLine($"Long: {ra.Longitude}");
                foreach (Threat t in ra.Threats)
                {
                    Console.WriteLine($"    Threat: {t.Title}");
                    Console.WriteLine($"    Level: {t.Level}");
                }
                Console.WriteLine();
            }
        }
    }
}
