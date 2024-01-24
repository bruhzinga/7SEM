using Newtonsoft.Json;

namespace PWS_3.Dto
{
    public class GetRequestDto
    {
        [JsonProperty("format")]
        public string Format { get; set; } = "json";
        
        [JsonProperty("limit")]
        public int Limit { get; set; } = 999999;
        
        [JsonProperty("sort")]
        public string Sort { get; set; } = string.Empty;
        
        [JsonProperty("offset")]
        public int Offset { get; set; }
        
        [JsonProperty("minid")]
        public int Minid { get; set; }
        
        [JsonProperty("maxid")]
        public int Maxid { get; set; } = 999999;
        
        [JsonProperty("like")]
        public string Like { get; set; }
        
        [JsonProperty("globallike")]
        public string Globallike { get; set; }
        
        [JsonProperty("columns")]
        public string Columns { get; set; } = "id,name,phone";
        
    }
}