using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class MobileTestingProduct
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("ConfiguringProductId")]
        public int ConfiguringProductId { get; set; }
        [JsonIgnore]
        public ConfiguringProduct ConfiguringProduct { get; set; }
    
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public double Nonlinearity { get; set; }
        public double Inaccuracy { get; set; }
        public double СhangeShiftZero { get; set; }
        public double СhangeTransformation { get; set; }
        public double HysteresisShiftZero { get; set; }
        public double HysteresisTransformation { get; set; }

        public CalibrationProduct CalibrationProduct { get; set; }

        public MobileTestingProduct () { }

        public MobileTestingProduct (Author author, string place, DateTime date,
            double nonlinearity, double inaccuracy, double changeShiftZero, double changeTransformation,
            double hysteresisShiftZero, double hysteresisTransformation,
            int id, int authorId, int configuringProductId, ConfiguringProduct configuringProduct)
        {
            Id = id;

            AuthorId = authorId;
            Author = author;

            ConfiguringProduct = configuringProduct;
            ConfiguringProductId = configuringProductId;

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
