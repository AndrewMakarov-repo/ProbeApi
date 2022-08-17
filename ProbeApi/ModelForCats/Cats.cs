using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProbeApi.ModelForCats
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FactItem
    {
        [JsonProperty("fact")]
        public string Fact { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }
    }

    public class FactsDTO
    {
        [JsonProperty("data")]
        public List<FactItem> Data { get; set; }
    }
}
