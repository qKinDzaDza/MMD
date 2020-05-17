using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class ConfiguringProduct
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        public bool ResultConfiguring { get; set; }
        public string ReasonDefects { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("MakeProductId")]
        public string MakeProductId { get; set; }
        [JsonIgnore]
        public MakeProduct MakeProduct { get; set; }

        public MobileTestingProduct MobileTestingProduct { get; set; }

        public ConfiguringProduct () { }

        public ConfiguringProduct (MakeProduct makeProduct, Author author, DateTime date,
            bool resultConfiguring, string reasonDefects, string makeProductId,
            int authorId, int id)
        {
            Id = id;

            MakeProductId = makeProductId;
            MakeProduct = makeProduct;

            AuthorId = authorId;
            Author = author;

            Date = date;
            ResultConfiguring = resultConfiguring;
            ReasonDefects = reasonDefects;
        }
    }
}
