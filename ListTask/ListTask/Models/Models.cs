using System;
namespace ListTask.Models
{
    public class MainTask
    {
        public Guid Id = Guid.NewGuid();
        public string Name { get; set; }
        public string About { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateDead { get; set; }

        public MainTask(string name, string about, DateTime dateadd, DateTime datedead)
        {
            Name = name;
            About = about;
            DateAdd = dateadd;
            DateDead = datedead;
        }

        public void Show()
        {
            Console.WriteLine("Id " + Id + " Name " + Name + " About " + About + "\nDateAdd " + DateAdd + " DateDead " + DateDead);
        }

    }
}
