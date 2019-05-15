using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HumanRisksAssignment.Models
{
    class RiskAssessment
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public List<Threat> Threats { get; }
    }
}
