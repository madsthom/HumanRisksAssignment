using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HumanRisksAssignment.Models
{
    public class RiskAssessment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Threat> Threats { get; set; }

        public RiskAssessment(string title, double latitude, double longitude)
        {
            Title = title;
            Latitude = latitude;
            Longitude = longitude;
            Threats = new List<Threat>();
        }
    }
}
