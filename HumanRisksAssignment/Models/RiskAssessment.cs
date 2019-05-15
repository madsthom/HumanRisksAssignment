using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanRisksAssignment.Models
{
    class RiskAssessment
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Threat> Threats;
    }
}
