using HumanRisksAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HumanRisksAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new RiskAssessmentContext())
            {
                var ra1 = new RiskAssessment("Some Assessment", 20, 30);
                var t1 = new Threat("Some Threat", 1);
                var t2 = new Threat("Some Other Threat", 3);
                ra1.Threats.Add(t1);
                ra1.Threats.Add(t2);
                db.RiskAssessments.Add(ra1);
                db.SaveChanges();
            }

            using (var db = new RiskAssessmentContext())
            {
                // Fetch RiskAssessments from db including Threats
                var raList = db.RiskAssessments.Include(r => r.Threats).ToList();

                // Go through RiskAssessments and write to console
                foreach(RiskAssessment ra in raList)
                {
                    Console.WriteLine($"RA: {ra.Title}");
                    Console.WriteLine($"Lat: {ra.Latitude}");
                    Console.WriteLine($"Long: {ra.Longitude}");
                    foreach(Threat t in ra.Threats)
                    {
                        Console.WriteLine($"    Threat: {t.Title}");
                        Console.WriteLine($"    Level: {t.Level}");
                    }
                }
            }


        }
    }
}
