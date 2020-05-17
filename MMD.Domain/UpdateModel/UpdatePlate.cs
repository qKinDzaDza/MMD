using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.UpdateModel
{
    public class UpdatePlate
    {
        public string Id { get; set; }
        
        [NotMapped]
        public List<string> AccelerometerIds { get; set; }

        [JsonIgnore]
        public List<Accelerometer> Accelerometer { get; set; }

        [NotMapped]
        public List<string> GyroscopeIds { get; set; }

        [JsonIgnore]
        public List<Gyroscope> Gyroscope { get; set; }

        public UpdatePlate() { }

    }
}
