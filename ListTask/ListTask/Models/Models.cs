using System;
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
    public class MainTask
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("about")]
        public string About { get; set; }
        [JsonProperty("dateAdd")]
        public DateTime DateAdd { get; set; }
        [JsonProperty("dateDeadline")]
        public DateTime DateDead { get; set; }
        public void Show()
        {
            Console.WriteLine("Id " + Id + " Name " + Name + " About " + About + "\nDateAdd " + DateAdd + " DateDead " + DateDead);
        }
    }
}
