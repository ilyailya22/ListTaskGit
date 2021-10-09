using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ListTask.Models
{
    public class BaseTask
    {
        public BaseTask()
        {
        }

        public BaseTask(int number, Guid id, string name, string about, DateTime dateAdd, DateTime dateDead)
        {
            Number = number;
            Id = id;
            Name = name;
            About = about;
            DateAdd = dateAdd;
            DateDead = dateDead;
        }

        public int Number { get; set; } = 1;

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

        public void ShowNameDate()
        {
            Console.WriteLine(Name + " - " + DateDead);
        }
    }
}
