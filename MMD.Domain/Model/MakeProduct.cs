using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class MakeProduct
    {
        public string Id{ get; set; }

        [ForeignKey("AssemblyMms")]
        public string AssemblyMmsId { get; set; }
        [JsonIgnore]
        public AssemblyMms AssemblyMms { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public int? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public DateTime Date { get; set; }
        public string NumberOfApplication { get; set; }

        public ConfiguringProduct ConfiguringProduct { get; set; }


        public MakeProduct () { }
        public MakeProduct (string id, AssemblyMms assemblyMms, Author author,
            DateTime date, string numberOfApplication,
            int authorId, int warehouseId, string assemblyMmsId, Warehouse warehouse)
        {
            Id = id;

            WarehouseId = warehouseId;
            Warehouse = warehouse;

            AssemblyMmsId = assemblyMmsId;
            AssemblyMms = assemblyMms;

            //AuthorId = authorId;
            //Author = author;

            Date = date;
            NumberOfApplication = numberOfApplication;
        }
    }
}
