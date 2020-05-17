using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class Consignment
    {
        public string Id { get; set; }
        [NotMapped]
        public List<string> AssemblyMmsIds { get; set; }

        [JsonIgnore]
        public List<AssemblyMms> AssemblyMms { get; set; }
     
        public Consignment() { }
        public Consignment (string id, List<AssemblyMms> assemblyMms)
        {
            Id = id;
            AssemblyMms = assemblyMms;
        }
    }
}
