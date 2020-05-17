using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class Accelerometer
    {
        public string Id { get; set; }

        public double Ea1 { get; set; }
        public double Ea1_3v { get; set; }
        public double Ea2 { get; set; }
        public double Ea2_3v { get; set; }
        public double Ed1 { get; set; }
        public double Ed1_3v { get; set; }
        public double Ed2 { get; set; }
        public double Ed2_3v { get; set; }

        [NotMapped]
        public string PlateId { get; set; }
        [JsonIgnore]
        public Plate Plate { get; set; }

        public AssemblyMms AssemblyMms { get; set; }

        public Accelerometer() { }
        public Accelerometer (string id, Plate plate, double ea1,
            double ea1_3v, double ea2, double ea2_3v, double ed1,
            double ed1_3v, double ed2, double ed2_3v, AssemblyMms assemblyMms, string plateId)
        {
            Id = id;
            
            Ea1 = ea1;
            Ea1_3v = ea1_3v;
            Ea2 = ea2;
            Ea2_3v = Ea2_3v;
            Ed1 = ed1;
            Ed2 = ed2;
            Ed2_3v = ed2_3v;

            AssemblyMms = assemblyMms;

            PlateId = plateId;
            Plate = plate;
        }

    }
}
