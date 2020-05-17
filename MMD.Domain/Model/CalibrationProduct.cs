using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class CalibrationProduct
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("MobileTestingProductId")]
        public int MobileTestingProductId { get; set; }

        [JsonIgnore]
        public MobileTestingProduct MobileTestingProduct { get; set; }
        
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public double Nonlinearity { get; set; }
        public double Inaccuracy { get; set; }
        public double СhangeShiftZero { get; set; }
        public double СhangeTransformation { get; set; }
        public double HysteresisShiftZero { get; set; }
        public double HysteresisTransformation { get; set; }
        public StationaryTestingProduct StationaryTestingProduct{ get; set; }
        public CalibrationProduct() { }
        public CalibrationProduct ( Author author, string place, DateTime date,
            double nonlinearity, double inaccuracy, double changeShiftZero, double changeTransformation,
            double hysteresisShiftZero, double hysteresisTransformation,
            int id, int authorId, int mobileTestingProductId, MobileTestingProduct mobileTestingProduct)
        {
            Id = id;

            AuthorId = authorId;
            Author = author;

            MobileTestingProduct = mobileTestingProduct;
            MobileTestingProductId = mobileTestingProductId;

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
