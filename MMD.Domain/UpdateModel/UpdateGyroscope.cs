using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.UpdateModel
{
    public class UpdateGyroscope
    {
        public string Id { get; set; }

        public double? ParameterF2 { get; set; }
        public double? ParameterF1 { get; set; }
        public double? ParameterQ1 { get; set; }
        public double? ParameterQ2 { get; set; }
        public double? ParameterQ { get; set; }
        public double? DifferentialF { get; set; }
        public double? DifferentialFQ { get; set; }

        public AssemblyMms AssemblyMms { get; set; }

        public string PlateId { get; set; }
        public Plate Plate { get; set; }

        public UpdateGyroscope() { }
    }
}
