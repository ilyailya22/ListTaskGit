using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ListTask.Models
{
    public class MainTask : BaseTask
    {
        public MainTask()
        {
        }

        public MainTask(int number, Guid id, string name, string about, DateTime dateAdd, DateTime dateDead, List<SubTask> children)
            : base()
        {
            Children = children;
        }

        [JsonProperty("children")]
        public List<SubTask> Children { get; set; }
    }
}
