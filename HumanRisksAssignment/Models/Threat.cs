using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanRisksAssignment.Models
{
    public class Threat
    { 
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int Level { get; set; }
        
        public Guid RiskAssessmentId { get; set; }
        public RiskAssessment RiskAssessment { get; set; }
    }
}
