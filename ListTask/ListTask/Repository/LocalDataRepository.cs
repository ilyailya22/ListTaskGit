using System;
using System.Collections.Generic;
using ListTask.Models;
using Newtonsoft.Json;

namespace ListTask.Repository
{
    public class LocalDataRepository : IRepository
    {
        private List<MainTask> _taskRepository;

        public LocalDataRepository()
        {
            _taskRepository = new List<MainTask>();
        }

        public LocalDataRepository(int size)
        {
            _taskRepository = new List<MainTask>(size);
        }

        public void Add(MainTask taskRepository)
        {
            _taskRepository.Add(taskRepository);
        }

        public void Delete(Guid taskRepository)
        {
            int number = int.Parse(Console.ReadLine());
            int tmp = 0;
            foreach (var i in _taskRepository)
            {
                if (i.Number == number)
                {
                    tmp = 1;
                    _taskRepository.Remove(i);
                    Console.WriteLine("Удаление успешно выполнено");
                    break;
                }
            }

            if (tmp != 1)
            {
                Console.WriteLine("Удаление не выполнена, такого имени нет");
            }
        }

        public void Print()
        {
            foreach (var i in _taskRepository)
            {
                i.Show();
            }
        }

        public void Printsome(Guid taskRepository)
        {
            int number = int.Parse(Console.ReadLine());
            int tmp = 0;
            foreach (var i in _taskRepository)
            {
                if (i.Number == number)
                {
                    tmp = 1;
                    i.Show();
                    Console.WriteLine("Вывод успешно выполнен");
                    break;
                }
            }

            if (tmp != 1)
            {
                Console.WriteLine("Такого номера не");
            }
        }

        public void DeleteAll()
        {
            _taskRepository.Clear();
        }

        public void Menu()
        {
            string menu;
            do
            {
                LocalDataRepository localTaskRepository = new LocalDataRepository();
                Console.WriteLine("add\nadd-task\nadd-subtask\nprint-all\nprint\nedit\ndrop\nexit");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "add":
                        {
                            string jsonString =
                               @"{""tasks"" : [
                                ""id"" : ""8a92b9c7-c04d-4d81-9bd8-e2c0e798ce1d"",
      ""name"" : ""Create mock api"",
      ""about"" : ""Generate mock api call"",
      ""dateAdd"" : ""2021-09-28T21:30:00"",
      ""dateDeadline"" : ""2021-10-10T21:10:00"",
      ""children"" : [
                                ""id"": ""dc787b7f-f0d5-4b73-9b75-2099f62c60d0"",
          ""parent"": ""8a92b9c7-c04d-4d81-9bd8-e2c0e798ce1d"",
          ""name"": ""Create mock api for get"",
          ""about"": ""Generate mock api for get call"",
          ""dateAdd"": ""2021-09-28T21:30:00"",
          ""dateDeadline"": ""2021-10-10T21:10:00""
                     ]
                                              ]
}
";
                            MainTaskJson mainTaskRepository =
                            JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
                            MainTask mainTaskobj = new MainTask();
                            foreach (var i in mainTaskRepository.Task)
                            {
                                mainTaskobj = i;
                            }

                            localTaskRepository.Add(mainTaskobj);
                            break;
                        }

                    case "add-task":
                        {
                            string jsonString =
                                @"{""tasks"" : [
                                ""id"" : ""8a92b9c7-c04d-4d81-9bd8-e2c0e798ce1d"",
      ""name"" : ""Create mock api"",
      ""about"" : ""Generate mock api call"",
      ""dateAdd"" : ""2021-09-28T21:30:00"",
      ""dateDeadline"" : ""2021-10-10T21:10:00""
]
}
";
                            MainTaskJson mainTaskRepository =
                            JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
                            MainTask mainTaskobj = new MainTask();
                            foreach (var i in mainTaskRepository.Task)
                            {
                                mainTaskobj = i;
                            }

                            localTaskRepository.Add(mainTaskobj);
                            break;
                        }

                    case "add-subtask":
                        {
                            string jsonString =
                                @"{""task"":[
""children"":[
""id"": ""dc787b7f-f0d5-4b73-9b75-2099f62c60d0"",
          ""parent"": ""8a92b9c7-c04d-4d81-9bd8-e2c0e798ce1d"",
          ""name"": ""Create mock api for get"",
          ""about"": ""Generate mock api for get call"",
          ""dateAdd"": ""2021-09-28T21: 30:00"",
          ""dateDeadline"": ""2021 - 10 - 10T21: 10:00""
             ]
                                            ]
                            }
";
                            MainTaskJson mainTaskRepository =
                            JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
                            MainTask mainTaskobj = new MainTask();
                            foreach (var i in mainTaskRepository.Task)
                            {
                                mainTaskobj = i;
                            }

                            localTaskRepository.Add(mainTaskobj);
                            break;
                        }

                    case "print-all":
                        {
                            localTaskRepository.Print();
                            break;
                        }

                    case "print":
                        {
                            Guid id = Guid.NewGuid();
                            localTaskRepository.Printsome(id);
                            break;
                        }

                    case "edit":
                        {
                            Console.WriteLine();
                            break;
                        }

                    case "delete":
                        {
                            Guid id = Guid.NewGuid();
                            localTaskRepository.Delete(id);
                            break;
                        }

                    case "drop":
                        {
                            localTaskRepository.DeleteAll();
                            break;
                        }

                    case "exit": return;

                    default: break;
                }
            }
            while (true);
        }
    }
}
