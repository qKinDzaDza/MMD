using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.UpdateModel
{
    public class UpdateCalibrationMms
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public MobileTestingMms MobileTestingMms { get; set; }
        public int MobileTestingMmsId { get; set; }

        public string Place { get; set; }
        public DateTime? Date { get; set; }
        public double? Nonlinearity { get; set; }
        public double? Inaccuracy { get; set; }
        public double? СhangeShiftZero { get; set; }
        public double? СhangeTransformation { get; set; }
        public double? HysteresisShiftZero { get; set; }
        public double? HysteresisTransformation { get; set; }
        public StationaryTestingMms StationaryTestingMms { get; set; }
        public UpdateCalibrationMms() { }
    }
}
