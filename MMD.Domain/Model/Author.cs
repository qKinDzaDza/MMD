using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MMD.Domain.Model
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }
       
        [NotMapped]
        public List<string> AssemblyMmsIds { get; set; }
        [JsonIgnore]
        public List<AssemblyMms> AssemblyMms { get; set; }
        
        
        [NotMapped]
        public List<string> MakeProductIds { get; set; }
        [JsonIgnore]
        public List<MakeProduct> MakeProduct { get; set; }
        
        [NotMapped]
        public List<int> CalibrationMmsIds { get; set; }
        [JsonIgnore]
        public List<CalibrationMms> CalibrationMms { get; set; }
       
        [NotMapped]
        public List<int> ConfiguringMmsIds { get; set; }
        [JsonIgnore]
        public List <ConfiguringMms> ConfiguringMms { get; set; }
       
        [NotMapped]
        public List<int> MobileTestingMmsIds { get; set; }
        [JsonIgnore]
        public List <MobileTestingMms> MobileTestingMms { get; set; }
        
        [NotMapped]
        public List<int> StationaryTestingMmsIds { get; set; }
        [JsonIgnore]
        public List<StationaryTestingMms> StationaryTestingMms { get; set; }
        
        [NotMapped]
        public List<int> CalibrationProductIds { get; set; }
        [JsonIgnore]
        public List<CalibrationProduct> CalibrationProduct { get; set; }

        [NotMapped]
        public List<int> ConfiguringProductIds { get; set; }
        [JsonIgnore]
        public List<ConfiguringProduct> ConfiguringProduct { get; set; }

        [NotMapped]
        public List<int> MobileTestingProductIds { get; set; }
        [JsonIgnore]
        public List<MobileTestingProduct> MobileTestingProduct { get; set; }

        [NotMapped]
        public List<int> StationaryTestingProductIds { get; set; }
        [JsonIgnore]
        public List<StationaryTestingProduct> StationaryTestingProduct { get; set; }

        [NotMapped]
        public List<int> WarehouseIds { get; set; }
        [JsonIgnore]
        public List<Warehouse> Warehouse { get; set; }
        
        public Author () { }

    }
}
