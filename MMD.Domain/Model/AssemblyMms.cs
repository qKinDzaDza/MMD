using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Net;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class AssemblyMms
    {
        
        public string Id { get; set; }

        [ForeignKey("Accelerometer")]
        public string AccelerometerId { get; set; }

        [JsonIgnore]
        public Accelerometer Accelerometer { get; set; }

        [ForeignKey("Gyroscope")]
        public string GyroscopeId { get; set; }
        [JsonIgnore]
        public Gyroscope Gyroscope { get; set; }
        
        public DateTime Date { get; set; }
        public string TypeOfIc { get; set; }
        public string StructureOfSensor { get; set; }
        public int Substrate { get; set; }

        public string ConsignmentId { get; set; }
        public Consignment Consignment { get; set; }
       
        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public ConfiguringMms ConfiguringMms { get; set; }

        public MakeProduct MakeProduct { get; set; }

        public AssemblyMms() { }

        public AssemblyMms (string id, Accelerometer accelerometer, Gyroscope gyroscope, DateTime date,
            string typeOfIc, string structureOfSensor, Author author, int substrate, Consignment consignment,
            int authorId, string consignmentId, ConfiguringMms configuringMms, MakeProduct makeProduct)
        {
            Id = id;

            Accelerometer = accelerometer;

            Gyroscope = gyroscope;
            
            Date = date;
            TypeOfIc = typeOfIc;
            StructureOfSensor = structureOfSensor;
            Substrate = substrate;

            ConsignmentId = consignmentId;
            Consignment = consignment;

            Author = author;
            AuthorId = authorId;

            ConfiguringMms = configuringMms;

            MakeProduct = makeProduct;
        }
    }
}
