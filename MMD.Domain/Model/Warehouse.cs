using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
   public class Warehouse
    {
        public int Id { get; set; }
       
        [NotMapped]
        public List<string> MakeProductIds { get; set; }
        [JsonIgnore]
        public List<MakeProduct> MakeProduct { get; set; }
        // public List<Consignment> Consignment { get; set;}

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public DateTime Date { get; set; }

        public Warehouse () { }
        public Warehouse (List<MakeProduct> makeProduct, Author author, DateTime date,
            int authorId, int id)
        {
            Id = id;

            AuthorId = authorId;
            Author = author;

            MakeProduct = makeProduct;
      
            Date = date;
        }
    }
}
