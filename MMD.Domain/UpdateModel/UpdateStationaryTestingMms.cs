using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.UpdateModel
{
   public class UpdateStationaryTestingMms
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public int CalibrationMmsId { get; set; }
        public CalibrationMms CalibrationMms { get; set; }

        public double? AlanInstability { get; set; }
        public double? PowerDensity { get; set; }
        public DateTime? Date { get; set; }
        public string Place { get; set; }

        public UpdateStationaryTestingMms() { }
    }
}
