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

        private double _latitude;
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

        private double _longitude;
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
