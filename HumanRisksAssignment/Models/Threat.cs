using System;
using System.Collections.Generic;
using System.Text;

namespace HumanRisksAssignment.Models
{
    class Threat
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public int Level { get; set; }
        public string RiskAssessmentId { get; }

        public Threat()
        {

        }
    }
}
