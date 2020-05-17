using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMD.Domain.UpdateModel
{
    public class UpdateConfiguringProduct
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }
        public bool? ResultConfiguring { get; set; }
        public string ReasonDefects { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public string MakeProductId { get; set; }
        public MakeProduct MakeProduct { get; set; }

        public MobileTestingProduct MobileTestingProduct { get; set; }

        public UpdateConfiguringProduct() { }
    }
}
