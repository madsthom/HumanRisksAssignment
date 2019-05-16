using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanRisksAssignment.Models
{
    public class Threat
    {
        [NotMapped]
        int _level;

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Range(0, 2)]
        public int Level
        {
            get { return _level; }
            set
            {
                if (value >= 0 && value <= 2)
                {
                    _level = value;
                }
                else
                {
                    // TODO: Add exception instead.
                    Console.WriteLine($"Error: No threat level of {value}. Threat level set to default (0)");
                    _level = 0;
                }
            }
        }

        [ForeignKey("RiskAssessment")]
        public Guid RiskAssessmentId { get; set; }
        public RiskAssessment RiskAssessment { get; set; }

        // Constructor
        public Threat(string title, int level)
        {
            Title = title;
            Level = level;
        }

    }
}
