using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.UpdateModel
{
    public class UpdateMakeProduct
    {
        public string Id { get; set; }

        [ForeignKey("AssemblyMms")]
        public string AssemblyMmsId { get; set; }
        [JsonIgnore]
        public AssemblyMms AssemblyMms { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public int? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public DateTime? Date { get; set; }
        public string NumberOfApplication { get; set; }

        public ConfiguringProduct ConfiguringProduct { get; set; }

        public UpdateMakeProduct() { }
    }
}
