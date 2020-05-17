using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.UpdateModel
{
   public class UpdateCalibrationProduct
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public MobileTestingProduct MobileTestingProduct { get; set; }
        public int MobileTestingProductId { get; set; }

        public string Place { get; set; }
        public DateTime? Date { get; set; }
        public double? Nonlinearity { get; set; }
        public double? Inaccuracy { get; set; }
        public double? СhangeShiftZero { get; set; }
        public double? СhangeTransformation { get; set; }
        public double? HysteresisShiftZero { get; set; }
        public double? HysteresisTransformation { get; set; }
        public StationaryTestingProduct StationaryTestingProduct { get; set; }
        public UpdateCalibrationProduct() { }
    }
}
