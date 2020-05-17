using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class MobileTestingMms
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("ConfiguringMmsId")]
        public int ConfiguringMmsId { get; set; }
        
        [JsonIgnore]
        public ConfiguringMms ConfiguringMms { get; set; }

        public string Place { get; set; }
        public DateTime Date { get; set; }
        public double Nonlinearity { get; set; }
        public double Inaccuracy { get; set; }
        public double СhangeShiftZero { get; set; }
        public double СhangeTransformation { get; set; }
        public double HysteresisShiftZero { get; set; }
        public double HysteresisTransformation { get; set; }

        public CalibrationMms CalibrationMms { get; set; }
        public MobileTestingMms () { }
        public MobileTestingMms (Author author, string place, DateTime date,
            double nonlinearity, double inaccuracy, double changeShiftZero, double changeTransformation,
            double hysteresisShiftZero, double hysteresisTransformation,
            int id, int authorId, int configuringMmsId, ConfiguringMms configuringMms)
        {
            Id = id;

            ConfiguringMmsId = configuringMmsId;
            ConfiguringMms = configuringMms;

            AuthorId = authorId;
            Author = author;

            Place = place;
            Date = date;
            Nonlinearity = nonlinearity;
            Inaccuracy = inaccuracy;
            СhangeShiftZero = changeShiftZero;
            СhangeTransformation = changeTransformation;
            HysteresisShiftZero = hysteresisShiftZero;
            HysteresisTransformation = hysteresisTransformation;
        }

    }
}
