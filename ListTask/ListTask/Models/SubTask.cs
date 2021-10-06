﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ListTask.Models
{
    public class SubTask : MainTask
    {
        [JsonProperty("parent")]
        public Guid Parent { get; set; }
    }
}