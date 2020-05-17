using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.UpdateModel
{
   public class UpdateConsignment
    {
        public string Id { get; set; }

        [NotMapped]
        public List<string> AssemblyMmsIds { get; set; }

        [JsonIgnore]
        public List<AssemblyMms> AssemblyMms { get; set; }

        public UpdateConsignment() { }
    }
}
