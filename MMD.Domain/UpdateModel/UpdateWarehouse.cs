using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.UpdateModel
{
    public class UpdateWarehouse
    {
        public int Id { get; set; }
        [NotMapped]
        public List<string> MakeProductIds { get; set; }
        [JsonIgnore]
        public List<MakeProduct> MakeProduct { get; set; }
        // public List<Consignment> Consignment { get; set;}

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public DateTime? Date { get; set; }

        public UpdateWarehouse() { }
    }
}
