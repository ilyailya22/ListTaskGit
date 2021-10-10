using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ListTask.Models
{
    public class MainTask : BaseTask
    {
        [JsonProperty("children")]
        public List<SubTask> Children { get; set; }
    }
}
