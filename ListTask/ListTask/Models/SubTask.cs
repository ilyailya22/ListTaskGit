using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ListTask.Models
{
    public class SubTask : BaseTask
    {
        [JsonProperty("parent")]
        public int Parent { get; set; }
    }
}
