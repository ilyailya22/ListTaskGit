using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ListTask.Models
{
    public class MainTask : BaseTask
    {
        [JsonProperty("children")]
        [NotMapped]
        public List<SubTask> Children { get; set; }
    }
}
