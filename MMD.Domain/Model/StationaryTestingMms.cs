using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class StationaryTestingMms
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("CalibrationMmsId")]
        public int CalibrationMmsId { get; set; }
        [JsonIgnore]
        public CalibrationMms CalibrationMms { get; set; }

        public double AlanInstability { get; set; }
        public double PowerDensity { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }

        public StationaryTestingMms () { }
        public StationaryTestingMms (double alanInstability, double powerDensity,
            Author author, DateTime date, string place,
            int id, int authorId, int calibrationMmsId, CalibrationMms calibrationMms)
        {
            Id = id;

            AuthorId = authorId;
            Author = author;

            CalibrationMms = calibrationMms;
            CalibrationMmsId = calibrationMmsId;

            AlanInstability = alanInstability;
            PowerDensity = powerDensity;
            Date = date;
            Place = place;
        }
    }
}
