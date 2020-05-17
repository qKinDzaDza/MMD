using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class StationaryTestingProduct
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("CalibrationProductId")]
        public int CalibrationProductId { get; set; }
        [JsonIgnore]
        public CalibrationProduct CalibrationProduct { get; set; }
       
        public double AlanInstability { get; set; }
        public double PowerDensity { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }

        public StationaryTestingProduct () { }

        public StationaryTestingProduct(double alanInstability, double powerDensity,  Author author, 
            DateTime date, string place,
             int id, int authorId, int calibrationProductId, CalibrationProduct calibrationProduct)
        {
            Id = id;
            AuthorId = authorId;
            Author = author;

            CalibrationProduct = calibrationProduct;
            CalibrationProductId = calibrationProductId;

            AlanInstability = alanInstability;
            PowerDensity = powerDensity;
            Date = date;
            Place = place;
        }
    }
}
