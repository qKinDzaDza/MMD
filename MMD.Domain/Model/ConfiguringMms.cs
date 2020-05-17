using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class ConfiguringMms
    {
        public int Id { get; set; }
       
        public DateTime Date { get; set; }
        public bool ResultConfiguring { get; set; }
        public string ReasonDefects { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("AssemblyMms")]
        public string AssemblyMmsId { get; set; }
        [JsonIgnore]
        public AssemblyMms AssemblyMms { get; set; }
        public MobileTestingMms MobileTestingMms { get; set; }
        public ConfiguringMms() { }
        public ConfiguringMms (AssemblyMms assemblyMms, Author author, DateTime date,
            bool resultConfiguring, string reasonDefects, string assemblyMmsId,
            int authorId, int id)
        {
            Id = id;
            
            Date = date;
            ResultConfiguring = resultConfiguring;
            ReasonDefects = reasonDefects;

            AssemblyMms = assemblyMms;
            AssemblyMmsId = assemblyMmsId;

            AuthorId = authorId;
            Author = author;
        }
    }
}
