using System;
using System.Collections.Generic;
using ListTask.Models;
using ListTask.Repository;
using Newtonsoft.Json;

namespace ListTask.Controllers
{
    public class RepositoryController
    {
        private readonly IRepository _repository;

        public RepositoryController(IRepository repository)
        {
            _repository = repository;
        }

        public void Addmethod(MainTask taskRepository)
        {
            _repository.Add(taskRepository);
        }

        public void Deletemethod(int number)
        {
            _repository.Delete(number);
        }

        public void DeleteAllmethod()
        {
            _repository.DeleteAll();
        }

        public void Printmethod()
        {
            _repository.Print();
        }

        public void PrintByldmethod(int number)
        {
            _repository.PrintByld(number);
        }

        public void Editmethod(int number, MainTask task)
        {
            _repository.Edit(number, task);
        }

        public void Menumethod()
        {
            string menu;
            do
            {
                Console.WriteLine("add\nadd-task\nadd-subtask\nprint-all\nprint\nedit\ndrop\nexit");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "add":
                        {
                            /*                         string jsonString =
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
                                                     }*/

                            // _repository.Add(mainTaskobj);
                            try
                            {
                                Console.WriteLine("MainTask -- ");
                                MainTask mainTaskobj = new MainTask();
                                mainTaskobj.Number = int.Parse(Console.ReadLine());
                                mainTaskobj.Id = Guid.NewGuid();
                                mainTaskobj.About = Console.ReadLine();
                                mainTaskobj.DateAdd = DateTime.Parse(Console.ReadLine());
                                mainTaskobj.DateDead = DateTime.Parse(Console.ReadLine());
                                List<SubTask> subTasks = new List<SubTask>();
                                subTasks.Add(new SubTask
                                {
                                    Number = int.Parse(Console.ReadLine()),
                                    Id = Guid.NewGuid(),
                                    Parent = Guid.NewGuid(),
                                    About = Console.ReadLine(),
                                    DateAdd = DateTime.Parse(Console.ReadLine()),
                                    DateDead = DateTime.Parse(Console.ReadLine())
                                });
                                mainTaskobj.Children = subTasks;
                                _repository.Add(mainTaskobj);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(typeof(Exception));
                            }

                            break;
                        }

                    case "add-task":
                        {
                            /*string jsonString =
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
                         }*/
                            try
                            {
                                Console.WriteLine("BaseTask -- ");
                                MainTask mainTaskobj = new MainTask();
                                mainTaskobj.Number = int.Parse(Console.ReadLine());
                                mainTaskobj.Id = Guid.NewGuid();
                                mainTaskobj.About = Console.ReadLine();
                                mainTaskobj.DateAdd = DateTime.Parse(Console.ReadLine());
                                mainTaskobj.DateDead = DateTime.Parse(Console.ReadLine());
                                _repository.Add(mainTaskobj);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(typeof(Exception));
                            }

                            break;
                        }

                    case "add-subtask":
                        {
                            /*string jsonString =
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
                            }*/
                            try
                            {
                                Console.WriteLine("SubTask -- ");
                                MainTask mainTaskobj = new MainTask();
                                List<SubTask> subTasks = new List<SubTask>();
                                subTasks.Add(new SubTask
                                {
                                    Number = int.Parse(Console.ReadLine()),
                                    Id = Guid.NewGuid(),
                                    Parent = Guid.NewGuid(),
                                    About = Console.ReadLine(),
                                    DateAdd = DateTime.Parse(Console.ReadLine()),
                                    DateDead = DateTime.Parse(Console.ReadLine())
                                });
                                mainTaskobj.Children = subTasks;
                                _repository.Add(mainTaskobj);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(typeof(Exception));
                            }

                            break;
                        }

                    case "print-all":
                        {
                            _repository.Print();
                            break;
                        }

                    case "print":
                        {
                            int number = int.Parse(Console.ReadLine());
                            _repository.PrintByld(number);
                            break;
                        }

                    case "edit":
                        {
                            try
                            {
                                Console.WriteLine("number = ");
                                int number = int.Parse(Console.ReadLine());
                                MainTask mainTaskobj = new MainTask();
                                Console.WriteLine("MainTask -- ");
                                mainTaskobj.Number = int.Parse(Console.ReadLine());
                                mainTaskobj.Id = Guid.NewGuid();
                                mainTaskobj.About = Console.ReadLine();
                                mainTaskobj.DateAdd = DateTime.Parse(Console.ReadLine());
                                mainTaskobj.DateDead = DateTime.Parse(Console.ReadLine());
                                List<SubTask> subTasks = new List<SubTask>();
                                subTasks.Add(new SubTask
                                {
                                    Number = int.Parse(Console.ReadLine()),
                                    Id = Guid.NewGuid(),
                                    Parent = Guid.NewGuid(),
                                    About = Console.ReadLine(),
                                    DateAdd = DateTime.Parse(Console.ReadLine()),
                                    DateDead = DateTime.Parse(Console.ReadLine())
                                });
                                mainTaskobj.Children = subTasks;
                                _repository.Edit(number, mainTaskobj);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(typeof(Exception));
                            }

                            break;
                        }

                    case "delete":
                        {
                            int number = int.Parse(Console.ReadLine());
                            _repository.Delete(number);
                            break;
                        }

                    case "drop":
                        {
                            _repository.DeleteAll();
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