using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ListTask.Models
{
    public class SubTask : BaseTask
    {
        public SubTask()
        {
        }

        public SubTask(int number, Guid id, Guid parent, string name, string about, DateTime dateAdd, DateTime dateDead)
            : base()
        {
            Parent = parent;
        }

        [JsonProperty("parent")]
        public Guid Parent { get; set; }
    }
}
