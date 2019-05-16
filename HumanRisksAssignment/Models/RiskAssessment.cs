using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanRisksAssignment.Models
{
    public class RiskAssessment
    {
        [NotMapped]
        private double _latitude;
        [NotMapped]
        private double _longitude;

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                if (value >= -90 && value <= 90)
                {
                    _latitude = value;
                }
                else
                {
                    // TODO: Add exception instead.
                    Console.WriteLine($"Error: No such latitude value: {value}");
                    _latitude = 0;
                }
            }
        }

        public double Longitude
        {
            get { return _longitude; }
            set
            {
                if (value >= -180.0 && value <= 180.0)
                {
                    _longitude = value;
                }
                else
                {
                    // TODO: Add exception instead.
                    Console.WriteLine($"Error: No such latitude value: {value}");
                    _longitude = 0;
                }
            }
        }
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
