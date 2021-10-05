using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ListTask.Models
{
    public class MainTaskJson
    {
        [JsonProperty("tasks")]
        public List<MainTask> Task { get; set; }
    }
}
