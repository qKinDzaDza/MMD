using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class Gyroscope
    {
        public string Id { get; set; }
        
        public double ParameterF2 { get; set; }
        public double ParameterF1 { get; set; }
        public double ParameterQ1 { get; set; }
        public double ParameterQ2 { get; set; }
        public double ParameterQ { get; set; }
        public double DifferentialF { get; set; }
        public double DifferentialFQ { get; set; }

        public AssemblyMms AssemblyMms { get; set; }

        [NotMapped]
        public string PlateId { get; set; }
        [JsonIgnore]
        public Plate Plate { get; set; }

        public Gyroscope() { }
        public Gyroscope (string id, Plate plate, double parameterF2, double parameterF1, 
            double parameterQ1, double parameterQ2, double parameterQ, 
            double differentialF, double differentialFQ, string plateId, AssemblyMms assemblyMms)
        {
            Id = id;
            
            ParameterF1 = parameterF1;
            ParameterF2 = parameterF2;
            ParameterQ2 = parameterQ2;
            ParameterQ1 = parameterQ1;
            ParameterQ = parameterQ;
            DifferentialFQ = differentialFQ;
            DifferentialF = differentialF;

            Plate = plate;
            PlateId = plateId;

            AssemblyMms = assemblyMms;
        }
    }
}
