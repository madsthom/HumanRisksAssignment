using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanRisksAssignment.Models
{
    class Threat
    {
        [Key]
        public Guid Id { get; }
        public string Title { get; set; }
        [Range(0, 2, ErrorMessage = "No such Threat level")]
        public int Level { get; set; }
        [ForeignKey("RiskAssessment")]
        public string RiskAssessmentId { get; }
    }
}
