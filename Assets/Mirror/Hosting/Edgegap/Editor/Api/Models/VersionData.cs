using Newtonsoft.Json;

namespace Mirror.Hosting.Edgegap.Editor.Api.Models
{
    public class VersionData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }
    }
}
