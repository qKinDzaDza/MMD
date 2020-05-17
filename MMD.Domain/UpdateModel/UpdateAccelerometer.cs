using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.UpdateModel
{
    public class UpdateAccelerometer
    {
        public string Id { get; set; }

        public double? Ea1 { get; set; }
        public double? Ea1_3v { get; set; }
        public double? Ea2 { get; set; }
        public double? Ea2_3v { get; set; }
        public double? Ed1 { get; set; }
        public double? Ed1_3v { get; set; }
        public double? Ed2 { get; set; }
        public double? Ed2_3v { get; set; }

        public string PlateId { get; set; }
        public Plate Plate { get; set; }

        public AssemblyMms AssemblyMms { get; set; }

        public UpdateAccelerometer() { }
    }
}
