using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.UpdateModel
{
    public class UpdateMobileTestingProduct
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public int ConfiguringProductId { get; set; }
        public ConfiguringProduct ConfiguringProduct { get; set; }

        public string Place { get; set; }
        public DateTime? Date { get; set; }
        public double? Nonlinearity { get; set; }
        public double? Inaccuracy { get; set; }
        public double? СhangeShiftZero { get; set; }
        public double? СhangeTransformation { get; set; }
        public double? HysteresisShiftZero { get; set; }
        public double? HysteresisTransformation { get; set; }
        public CalibrationProduct CalibrationProduct { get; set; }
        public UpdateMobileTestingProduct() { }
    }
}
