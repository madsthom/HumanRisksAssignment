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
                var raList = db.RiskAssessments.Include(ra => ra.Threats).ToList();

                foreach (var ra in raList)
                {
                    PrintRiskAssessment(ra);
                }

                db.SaveChanges();

            }
        }

        public static void PrintRiskAssessment(RiskAssessment ra)
        {
            Console.WriteLine($"Assessment: {ra.Title}\n" +
                                  $"Lat: {ra.Latitude}\n" +
                                  $"Long: {ra.Longitude}");
            Console.WriteLine("Threats:");

            foreach (var t in ra.Threats)
            {
                Console.WriteLine($"    Threat: {t.Title}:");
                Console.WriteLine($"    Level: {t.Level}");
            }
        }
    }
}
