using MMD.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMD.Domain.UpdateModel
{
    public class UpdateConfiguringMms
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }
        public bool? ResultConfiguring { get; set; }
        public string ReasonDefects { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("AssemblyMms")]
        public string AssemblyMmsId { get; set; }

        public AssemblyMms AssemblyMms { get; set; }

        public MobileTestingMms MobileTestingMms { get; set; }
        public UpdateConfiguringMms() { }
    }
}
